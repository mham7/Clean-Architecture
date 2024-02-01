using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repos;

namespace Domain.Interfaces.Services
{
    public interface IDivisionService:IGenericServices<Division>
    {
        Task<List<Divlist>> GetDivisionsAsync(int div_id);
    }
}
