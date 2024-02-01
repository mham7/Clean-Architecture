using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IGenericServices<T> where T : class
    {

        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
