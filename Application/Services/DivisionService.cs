using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Contouring_App.Application.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly IUnitofWork _unit;

        public DivisionService(IUnitofWork unit)
        {
            _unit = unit;
        }
        public async Task Add(Division division)
        {
           await _unit.divs.Add(division);
        }

        public async Task Delete(Division division)
        {
           await _unit.divs.Delete(division);
        }

        public async Task<List<Divlist>> GetDivisionsAsync(int div_id)
        {
            return await _unit.divs.Get_Trainees_ManagersByDivID(div_id);
        }
        public async Task<IEnumerable<Division>> GetAll()
        {
            return await _unit.divs.GetAll();
        }

        public async Task<Division> GetByIdAsync(int id)
        {
            return await _unit.divs.GetById(id);
        }

        public async Task Update(Division division)
        {
           await _unit.divs.Update(division);
        }
    }
}
