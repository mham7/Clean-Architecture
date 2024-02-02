using Application.Interfaces.Repos;
using Domain.Entities;
using Domain.Entities.Dtos;

namespace Application.Interfaces.Services
{
    public interface IUserService:IGenericServices<Usercs>
    {
        Task<string> Login(Userdto user);
        Task<Userdto> Register(Usercs user);
        
    }
}
