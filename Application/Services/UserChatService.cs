using Application.Interfaces.Repos;
using Application.Interfaces.Repos.Utlities;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Utlities;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using MassTransit;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Application.Services
{
    public class UserChatService : GenericService<UserChat>, IUserChatService
    {
        private readonly IUnitofWork _Unit;
        private readonly IMessagingService _Messaging;
        private readonly IChatService _ChatService;
        private readonly IMapper _Mapper;
        private readonly IUserService _user;
        private readonly IProfilePicService _profile;
        private readonly IAuthenticator _auth;
        private readonly IKafkaProducer _kafkaProducer;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserChatService(IGenericRepo<UserChat> gen, IChatService ChatService, 
            IMessagingService Messaging, IUnitofWork Unit, 
            IMapper mapper,IProfilePicService profile, IUserService user, 
            IAuthenticator auth,IKafkaProducer kafkaProducer, IPublishEndpoint publishEndpoint) : base(gen)
        {
            _publishEndpoint=publishEndpoint;
            _kafkaProducer = kafkaProducer;
            _ChatService = ChatService;
            _Messaging = Messaging;
            _Unit = Unit;
            _Mapper = mapper;
            _user = user;
            _profile = profile;
            _auth = auth;
        
           

        }

        
        
        public async Task<Message> Post(MessageDto messagedto)
        {
            Message message = _Mapper.Map<Message>(messagedto);
            Expression<Func<UserChat, bool>> filter = u => (u.SenderId == messagedto.senderID && u.RecieverId == messagedto.recieverID)
            || (u.SenderId == messagedto.recieverID && u.RecieverId == messagedto.senderID);
            UserChat uchat = await _Unit._uchat.Get(filter);

            if (uchat == null)
            {
                Chats chat = await _ChatService.Post(DateTime.Now);
                message.ChatId = chat.ChatId;
                message.CreatedTime=DateTime.Now;
                message.IsRead = false;
                await _Unit.message.Post(message);
                UserChat s = new UserChat { ChatId = chat.ChatId, SenderId = messagedto.senderID, RecieverId = messagedto.recieverID };
                await post(s);
                await _publishEndpoint.Publish(message);
                //await _kafkaProducer.ProduceMessageAsync(message);
                await _Messaging.post(message);
            }
            else
            {
                message.ChatId = uchat.ChatId;
                message.CreatedTime=DateTime.Now;
                message.IsRead = false;
                //await _kafkaProducer.ProduceMessageAsync(message);
                await _publishEndpoint.Publish(message);
                await _Messaging.post(message);
            }
            return message;
        }

        public async Task<List<ChatDto>> GetInbox(int id)
        {
            List<ChatDto> chatDtos = new List<ChatDto>();
            List<UserChat> chat = await _Unit._chat.get(id);
            foreach (UserChat item in chat)
            {
                if (item.SenderId == id)
                {
                    User u = await _user.Get(item.RecieverId);
                    List<Message> msg = await _Messaging.GetInbox(item.ChatId);
                    Message topMessage = msg.OrderByDescending(m => m.CreatedTime).FirstOrDefault();
                    //ProfilePic pic = await _profile.Get(id);
                    ChatDto chatDto = new ChatDto
                    {
                        ChatId = item.ChatId,
                        UserId = item.RecieverId,
                        Name = u.FirstName,
                        //ProfilePic = pic.Profilepic1,
                        TopMessage = topMessage.MessageDetail

                    };

                    chatDtos.Add(chatDto);
                }
                else
                {
                    User u = await _user.Get(item.SenderId);
                    List<Message> msg = await _Messaging.GetInbox(item.ChatId);
                    Message topMessage = msg.OrderBy(m => m.CreatedTime).FirstOrDefault();
                    //ProfilePic pic = await _profile.Get(item.SenderId);
                    ChatDto chatDto = new ChatDto
                    {
                        ChatId = item.ChatId,
                        UserId = item.SenderId,
                        Name = u.FirstName,
                        //ProfilePic = pic.Profilepic1,
                        TopMessage = topMessage.MessageDetail
                    };

                    chatDtos.Add(chatDto);
                }


            }
            return chatDtos;

        }

        public async Task<List<Message>> Get(int userId, int chatId)
        {
            Expression<Func<UserChat, bool>> filter = u => (u.SenderId == userId && u.ChatId == chatId)
            || (u.RecieverId == userId && u.ChatId == chatId);
            UserChat uchat = await _Unit._uchat.Get(filter);
            if (_auth.ChatVerification(uchat))
            {
                List<Message> msgs= await _Messaging.GetInbox(chatId);
                msgs = msgs.OrderByDescending(m => m.CreatedTime).ToList();
                return msgs;
            }
            else
            {
                return null;
            }
        }
        public async Task<Message> Delete(int UserId,int MessageId)
        {
            Message msg = await _Messaging.Get(MessageId);
            Expression<Func<UserChat, bool>> filter = u => (u.SenderId == UserId && u.ChatId == msg.ChatId);
            UserChat uchat = await _Unit._uchat.Get(filter);
            if(uchat != null)
            {
               await _Messaging.Delete(msg);
                return msg;
            }
            else { return null; }
            
        }
       public async Task<UserChat> Put(int ChatId, int UserId)
        {
            
            Expression<Func<UserChat, bool>> filter = u => (u.SenderId == UserId && u.ChatId == ChatId)
            || (u.RecieverId == UserId && u.ChatId == ChatId);
            UserChat uchat = await _Unit._uchat.Get(filter);
            if(uchat != null && uchat.SenderId==UserId)
            {
                uchat.SenderId = 0;
                await Put(uchat);
                return uchat;
            }
            else if(uchat != null && uchat.RecieverId == UserId)
            {
                uchat.RecieverId = 0;
                await Put(uchat);
                return uchat;
            }
            else
            {
                return null;
            }
        }
    }
}
