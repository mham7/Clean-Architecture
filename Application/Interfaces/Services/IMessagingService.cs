using Application.Interfaces.Repos;
using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMessagingService:IGenericServices<Message>
    {
        Task<List<Message>> GetInbox(int Chatid);
    }
}
