using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IDevService
    {
        Task<Dev> GetById(int id);
        Task<IEnumerable<Dev>> GetAll();
        Task<List<Dev>> getStacklist(string ts);
        Task Add(Dev dev);
        Task Update(Dev dev);
        Task Delete(Dev dev);
    }
}
