using Application.Interfaces.Repos;
using Domain.Models;
using Domain.Models;
using Domain.Models.Dtos;

namespace Application.Interfaces.Services
{
    public interface IUserService:IGenericServices<User>
    {
        Task<string> Login(Userdto user);
        Task<Userdto> Register(UserRegInfo user);
        


    }
}
