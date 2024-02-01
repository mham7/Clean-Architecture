using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Services
{
    public interface IUserService:IGenericServices<Usercs>
    {
        Task<string> Login(Userdto user);
        Task<Userdto> Register(Usercs user);
        
    }
}
