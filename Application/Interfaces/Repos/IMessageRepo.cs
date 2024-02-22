using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
   public interface IMessageRepo : IGenericRepo<Message>
    {
        
        Task<Message> Patch(int id, string message);
        Task<List<Message>> Get(Expression<Func<Message, bool>> filter);
    }
}
