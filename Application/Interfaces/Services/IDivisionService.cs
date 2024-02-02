using Domain.Entities;
using Domain.Entities.Dtos;


namespace Application.Interfaces.Repos
{
    public interface IDivisionService:IGenericServices<Division>
    {
        Task<List<Divlist>> GetDivisionsAsync(int div_id);
    }
}
