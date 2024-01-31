using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Services
{
    public interface IDivisionService
    {
        Task Delete(Division division);
        Task Add(Division division);
        Task<List<Divlist>> GetDivisionsAsync(int div_id);
        Task<IEnumerable<Division>> GetAll();
        Task<Division> GetByIdAsync(int id);
        Task Update(Division division);


    }
}
