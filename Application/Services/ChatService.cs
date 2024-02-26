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
        private readonly IUserService _user;
        private readonly IProfilePicService _profile;
        
        public ChatService(IGenericRepo<Chats> gen, IUnitofWork unit, IUserService user,IProfilePicService profile) : base(gen)
        {
            _unit = unit;
            _user = user;
            _profile = profile;
           
        }

       
        public async Task<Chats> Post(DateTime a)
        {
            Chats b = new() { CreatedTime = a };
            await _unit._chat.Post(b);
            return b;
            }

       
    }
    }
