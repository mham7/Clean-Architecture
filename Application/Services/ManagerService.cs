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
        public async Task Add(Manager manager)
        {
           await _gen.Add(manager);
        }

        public async Task Delete(Manager manager)
        {
           await _gen.Delete(manager);
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {

            return await _gen.GetAll();
        }

        public async Task<Manager> GetById(int id)
        {
            return await _gen.GetById(id);
        }

        public async Task Update(Manager manager)
        {
            await _gen.Update(manager);
        }
    }
}
