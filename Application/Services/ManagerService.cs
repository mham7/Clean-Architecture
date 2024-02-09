using Domain.Entities;
using Domain.Entities.Dtos;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;

namespace Contouring_App.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitofWork _unit;

        public ManagerService(IUnitofWork unit) {
            _unit = unit;
        }
        public async Task Add(Manager manager)
        {
           await _unit.managers.Add(manager);
        }

        public async Task Delete(Manager manager)
        {
           await _unit.managers.Delete(manager);
        }

     

        public async Task<IEnumerable<Manager>> GetAll()
        {

            return await _unit.managers.GetAll();
        }

        public async Task<Manager> GetById(int id)
        {
            return await _unit.managers.GetById(id);
        }

        public async Task<List<Divlist>> TraineesAssignedToManager(Manager manager)
        {
           return await _unit.managers.GetTraineesUnderManager(manager);
        }

        public async Task Update(Manager manager)
        {
            await _unit.managers.Update(manager);
        }
    }
}
