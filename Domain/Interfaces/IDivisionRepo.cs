using Domain.Entities;
using Domain.Entities.Dtos;
namespace Domain.Interfaces.Repositories
{
    public interface IDivisionRepo
    {
        public List<Divlist> Get_Divisions(int division);
    }
}
