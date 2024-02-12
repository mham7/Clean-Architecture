using Domain.Models;
using Domain.Models;
using Domain.Models.Dtos;

namespace Application.Interfaces.Repos
{
    public interface IUserRepo : IGenericRepo<User> 
    {
        Task<User> Get(Userdto cred);
        
    }
}
