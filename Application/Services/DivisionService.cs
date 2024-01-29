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
        public async Task Add(Division division)
        {
           await _gen.Add(division);
        }

        public async Task Delete(Division division)
        {
           await _gen.Delete(division);
        }

        public async Task<List<Divlist>> GetDivisionsAsync(int div_id)
        {
           return await _unit.divs.Get_Divisions(div_id);
        }
        public async Task<IEnumerable<Division>> GetAll()
        {
            return await _gen.GetAll();
        }

        public async Task<Division> GetByIdAsync(int id)
        {
            return await _gen.GetById(id);
        }

        public async Task Update(Division division)
        {
           await _gen.Update(division);
        }
    }
}
