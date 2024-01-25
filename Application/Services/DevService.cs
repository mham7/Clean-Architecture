
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

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

        public List<Dev> getstacklist(string ts)
        {
           return _unit.devs.GetStackList(ts);
        }
        public void Add(Dev dev)
        {
            _gen.Add(dev);
        }

        public void Delete(Dev dev)
        {
            _gen.Delete(dev);
        }

        public IEnumerable<Dev> GetAll()
        {
            return _gen.GetAll();
        }

        public Dev GetById(int id)
        {
            Dev dev = _gen.GetById(id);
            return dev;
        }

        public void Update(Dev dev)
        {
            _gen.Update(dev);
        }
    }
}
