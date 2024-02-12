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

        public Task<T> Get(int id)
        {
            return _gen.Get(id);
        }

        public Task<IEnumerable<T>> Get()
        {
           return _gen.Get();
        }

        public Task Post(T Entity)
        {
            return _gen.Post(Entity);
        }

        public Task Put(T Entity)
        {
            return _gen.Put(Entity);
        }

        public Task Delete(T Entity)
        {
            return _gen.Delete(Entity);
        }
    }
}
