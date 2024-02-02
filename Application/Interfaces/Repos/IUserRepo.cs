using Domain.Entities;
using Domain.Entities.Dtos;

namespace Application.Interfaces.Repos
{
    public interface IUserRepo : IGenericRepo<Usercs> 
    {
        Task<Usercs> CheckAuthenticate(Userdto cred);
    }
}
