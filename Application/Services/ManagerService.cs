using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Contouring_App.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IGenericRepo<Manager> _gen;
        private readonly IUnitofWork _unit;

        public ManagerService(IUnitofWork unit, IGenericRepo<Manager> gen) {
            _unit = unit;
            _gen = gen;
        }
        public void Add(Manager manager)
        {
            _gen.Add(manager);
        }

        public void Delete(Manager manager)
        {
            _gen.Delete(manager);
        }

        public IEnumerable<Manager> GetAll()
        {

            return _gen.GetAll();
        }

        public Manager GetById(int id)
        {
            return _gen.GetById(id);
        }

        public void Update(Manager manager)
        {
             _gen.Update(manager);
        }
    }
}
