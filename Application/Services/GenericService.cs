using Application.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService<T>: IGenericServices<T> where T : class
    {
        private readonly IGenericRepo<T> _gen;
        public GenericService(IGenericRepo<T> gen)
        {
            _gen= gen;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
