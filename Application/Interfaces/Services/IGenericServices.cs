using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repos
{
    public interface IGenericServices<T> where T : class
    {

        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Post(T Entity);
        Task Put(T Entity);
        Task Delete(T Entity);
    }
}
