using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepo
    {
        Task<Usercs> CheckAuthenticate(Userdto cred);
    }
}
