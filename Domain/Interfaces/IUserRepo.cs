using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepo
    {
        Usercs CheckAuthenticate(Userdto cred);
    }
}
