using Domain.Models;
using Domain.Models;
using Domain.Models.Dtos;
using System.Linq.Expressions;

namespace Application.Interfaces.Repos
{
    public interface IUserRepo : IGenericRepo<User> 
    {
        Task<User> Get(Userdto cred);
        Task<List<User>> Get(Expression<Func<User, bool>> filter);
        Task<User> Patch(int id, Userdto cred);
    }
}
