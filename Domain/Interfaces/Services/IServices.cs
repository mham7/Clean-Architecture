using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServices<T> where T : class
    {
        Task Create(T entity);
        Task Update(int entityId, T entity);
        Task Delete(int entityId);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int entityId);
    }
}
