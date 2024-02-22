using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IUserChatRepo :  IGenericRepo<UserChat>
    {
        Task<UserChat> Get(Expression<Func<UserChat, bool>> filter);
        Task<List<UserChat>> get(int id);
    }
}
