using Domain.Entities;
using Domain.Entities.Dtos;
using System.Threading.Tasks;
namespace Application.Interfaces.Repos
{
    public interface IDivisionRepo:IGenericRepo<Division>
    {
        Task<List<Divlist>> Get_Trainees_ManagersByDivID(int division);
    }
}
