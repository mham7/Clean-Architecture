using Domain.Entities;
using Domain.Interfaces;
using Domain.Entities.Dtos;

namespace Domain.Interfaces
{
    public interface IDivisionService
    {
        public Division GetById(int id);
        public IEnumerable<Division> GetAll();
        public void Add(Division division);
        public void Update(Division division);
        public void Delete(Division division);
        public List<Divlist> GetDivisions(int div_id);
    }
}
