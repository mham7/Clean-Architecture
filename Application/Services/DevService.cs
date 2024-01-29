
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System.Runtime.CompilerServices;

namespace Contouring_App.Application.Services
{
    public class DevService : IDevService
    {
        private readonly IUnitofWork _unit;
        private readonly IGenericRepo<Dev> _gen;
      

        public DevService(IGenericRepo<Dev> gen, IUnitofWork unit)
        {
            _unit = unit;
            _gen = gen;
        }

        public async Task<List<Dev>> getStacklist(string ts)
        {
           return await _unit.devs.GetStackList(ts);
        }
        public async Task Add(Dev dev)
        {
            await _gen.Add(dev);
        }

        public async Task Delete(Dev dev)
        {
            await _gen.Delete(dev);
        }

        public async Task<IEnumerable<Dev>> GetAll()
        {
            return await _gen.GetAll();
        }

        public async Task<Dev> GetById(int id)
        {
            Dev dev = await _gen.GetById(id);
            return dev;
        }

        public async Task Update(Dev dev)
        {
            await _gen.Update(dev);
        }
    }
}
