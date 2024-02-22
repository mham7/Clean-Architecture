using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
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
        public UserChatService(IGenericRepo<UserChat> gen, IChatService ChatService, IMessagingService Messaging, IUnitofWork Unit, IMapper mapper,IProfilePicService profile, IUserService user) : base(gen)
        {
            _ChatService = ChatService;
            _Messaging = Messaging;
            _Unit = Unit;
            _Mapper = mapper;
            _user = user;
            _profile = profile;

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
                await _Messaging.post(message);
            }
            else
            {
                message.ChatId = uchat.ChatId;
                message.CreatedTime=DateTime.Now;
                message.IsRead = false;
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
                    Message topMessage = msg.OrderBy(m => m.CreatedTime).FirstOrDefault();
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
    }
}
