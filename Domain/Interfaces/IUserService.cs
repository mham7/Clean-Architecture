using Domain.Entities;
using Domain.Interfaces;
using Domain.Entities.Dtos;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        public Task<Usercs> GetById(int id);
        public Task<IEnumerable<Usercs>> GetAll();
        public Task<string> Login(Userdto user);
        public Task<Userdto> Register(Usercs user);
        public Task Add(Usercs users);
        public Task Update(Usercs users);
        public Task Delete(Usercs users);
    }
}
