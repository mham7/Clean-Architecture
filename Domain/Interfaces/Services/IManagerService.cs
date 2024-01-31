using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IManagerService
    {

         Task<Manager> GetById(int id);
         Task<IEnumerable<Manager>> GetAllAsync();
         Task Add(Manager manager);
         Task Update(Manager manager);
         Task Delete(Manager manager);
    }
}
