using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Models.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.Interfaces.Repos;

namespace Application.Services
{
    public class ChatService:GenericService<Chats>,IChatService
    {
        private readonly IUnitofWork _unit;
     
        public ChatService(IGenericRepo<Chats> gen, IUnitofWork unit) : base(gen)
        {
            _unit = unit;
        }

        public async Task<Chats> Post(DateTime a)
        {
            Chats b = new Chats { CreatedTime = a };
            await _unit._chat.Post(b);
            //if (chat == null)
            //{
            //    Chats b = new Chats { ChatId = 1, CreatedTime = a };
            //    await _unit.chat.Post(b);
            //    return b;
            //}
            //else
            //{
            //    int maxId = chat.Max(c => c.ChatId);
            //    maxId++;
            //    Chats b = new Chats { ChatId = maxId, CreatedTime = a };
            //    await _unit.chat.Post(b);
            return b;
            }
        }
    }
