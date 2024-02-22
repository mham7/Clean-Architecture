using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MessagingService:GenericService<Message>,IMessagingService
    {
        private readonly IUnitofWork _unit;
        private readonly IMapper _mapper;
        private readonly IChatService _chat;
        private readonly IGenericServices<UserChat> _uchat;
        private readonly IMessageRepo _messageRepo;
        public MessagingService(IGenericRepo<Message> gen,IGenericServices<UserChat> uchat, IChatService chat,IUnitofWork unit, IMapper mapper,IMessageRepo messageRepo) : base(gen)
        {
            _unit = unit; _mapper = mapper; 
            _chat = chat;
            _uchat = uchat;
            _messageRepo = messageRepo;

        }

        public async Task<Message> Post(MessageDto dto)
        {
            Message msg = _mapper.Map<Message>(dto);
            msg.CreatedTime= DateTime.Now;
            msg.IsRead = false;
            Expression<Func<UserChat, bool>> filter = u => (u.SenderId == dto.senderID && u.RecieverId == dto.recieverID) || (u.SenderId == dto.recieverID && u.RecieverId == dto.senderID);
            UserChat a= await _unit._uchat.Get(filter);

            if (a == null)
            {
               Chats c= await _chat.Post(DateTime.Now);
                msg.ChatId = c.ChatId;
                await _unit.message.Post(msg);
                UserChat s=new UserChat { ChatId=c.ChatId,SenderId=dto.senderID,RecieverId=dto.recieverID};
                await _uchat.post(s);
                
            }
            else
            {
                msg.ChatId = (int)a.ChatId;
                await _unit.message.Post(msg);
            }

            return msg;
        }

       public async Task<List<Message>> Get(int Chatid)
        {
            Expression<Func<Message, bool>> filter=u=>u.ChatId == Chatid;
            List<Message>a= await _messageRepo.Get(filter);
            return a;
        }
    }
}
