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

        public  async Task<string> Patch(int id, string message)
        {
            Message msg= await _unit.message.Get(id);
            msg.MessageDetail= message;
            await _unit.message.Put(msg);
            return msg.MessageDetail;

        }
        public async Task<List<Message>> GetInbox(int Chatid)
        {
            Expression<Func<Message, bool>> filter=u=>u.ChatId == Chatid;
            List<Message>a= await _messageRepo.Get(filter);
            if (a != null)
            {
                return a;
            }
            else
            {
                return null;
            }
        }
    }
}
