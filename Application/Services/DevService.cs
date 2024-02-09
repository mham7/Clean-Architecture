using Domain.Entities;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Services;
using System.Runtime.CompilerServices;

namespace Contouring_App.Application.Services
{
    public class DevService : IDevService
    {
        private readonly IUnitofWork _unit;
      

        public DevService(IUnitofWork unit)
        {
            _unit = unit;
        }

        public async Task<List<Dev>> getStacklist(string ts)
        {
           return await _unit.devs.GetDevelopersStackList(ts);
        }
        public async Task Add(Dev dev)
        {
            await _unit.devs.Add(dev);
        }

        public async Task Delete(Dev dev)
        {
            await _unit.devs.Delete(dev);
        }

        public async Task<IEnumerable<Dev>> GetAll()
        {
            return await _unit.devs.GetAll();
        }

        public async Task<Dev> GetById(int id)
        {
            Dev dev = await _unit.devs.GetById(id);
            return dev;
        }

        public async Task Update(Dev dev)
        {
            await _unit.devs.Update(dev);
        }
    }
}
