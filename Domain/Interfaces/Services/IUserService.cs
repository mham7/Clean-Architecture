using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Services
{
    public interface IUserService 
    {
        Task<Usercs> GetById(int id);
        Task<IEnumerable<Usercs>> GetAll();
        Task<string> Login(Userdto user);
        Task<Userdto> Register(Usercs user);
        Task Add(Usercs users);
        Task Update(Usercs users);
        Task Delete(Usercs users);
    }
}
