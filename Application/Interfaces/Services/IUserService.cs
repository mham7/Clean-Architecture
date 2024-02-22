using Application.Interfaces.Repos;
using Domain.Models;
using Domain.Models;
using Domain.Models.Dtos;

namespace Application.Interfaces.Services
{
    public interface IUserService:IGenericServices<User>
    {
        Task<string> Post(Userdto user);
        Task<Userdto> Post(UserRegInfo user);
        Task<string> Patch(int id,Userdto cred);
        Task<string> get(int id);


    }
}
