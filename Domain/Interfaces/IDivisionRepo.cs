using Domain.Entities;
using Domain.Entities.Dtos;
using System.Threading.Tasks;
namespace Domain.Interfaces.Repositories
{
    public interface IDivisionRepo
    {
        public Task<List<Divlist>> Get_Divisions(int division);
    }
}
