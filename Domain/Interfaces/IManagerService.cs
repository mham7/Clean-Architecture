using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IManagerService
    {

        public Manager GetById(int id);
        public IEnumerable<Manager> GetAll();
        public void Add(Manager manager);
        public void Update(Manager manager);
        public void Delete(Manager manager);
    }
}
