using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IManagerService
    {

        public Task<Manager> GetById(int id);
        public Task<IEnumerable<Manager>> GetAllAsync();
        public Task Add(Manager manager);
        public Task Update(Manager manager);
        public Task Delete(Manager manager);
    }
}
