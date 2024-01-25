using Domain.Entities;
using Domain.Entities.Dtos;
namespace Domain.Interfaces.Repositories
{
    public interface IGenericRepo<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
