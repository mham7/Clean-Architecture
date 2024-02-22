using Application.Interfaces.Repos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
  public interface IChatService:IGenericServices<Chats>

    {
        Task<Chats> Post(DateTime a);
    }
}
