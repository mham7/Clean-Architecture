using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Contouring_App.Application.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IGenericRepo<Division> _gen;
        private readonly IUnitofWork _unit;

        public DivisionService(IUnitofWork unit, IGenericRepo<Division> gen)
        {
            _gen = gen;
            _unit = unit;
        }
        public void Add(Division division)
        {
            _gen.Add(division);
        }

        public void Delete(Division division)
        {
            _gen.Delete(division);
        }

        public List<Divlist> GetDivisions(int div_id)
        {
           return _unit.divs.Get_Divisions(div_id);
        }
        public IEnumerable<Division> GetAll()
        {
            return _gen.GetAll();
        }

        public Division GetById(int id)
        {
            return _gen.GetById(id);
        }

        public void Update(Division division)
        {
            _gen.Update(division);
        }
    }
}
