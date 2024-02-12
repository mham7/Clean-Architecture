using Domain.Models;
using Domain.Models.Dtos;
namespace Application.Interfaces.Repos
{
    public interface IGenericRepo<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Post(T entity);
        Task Put(T entity);
        Task Delete(T entity);
    }
}
