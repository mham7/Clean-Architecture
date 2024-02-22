using Domain.Models.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repos;
using Application.Services;

namespace Application.Interfaces.Services
{
    public interface IUserChatService :IGenericServices<UserChat>
    {
        Task<List<ChatDto>> GetInbox(int userId);
        Task<Message> Post(MessageDto messagedto);


    }
}
