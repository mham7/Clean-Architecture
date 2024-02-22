using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IChatRepo : IGenericRepo<Chats>
    {
        Task<List<UserChat>> get(int id);
    }
}
