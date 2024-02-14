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

        public virtual Task<T> Get(int id)
        {
            return _gen.Get(id);
        }

        public virtual Task<IEnumerable<T>> Get()
        {
           return _gen.Get();
        }

        public virtual Task post(T Entity)
        {
            return _gen.Post(Entity);
        }

        public virtual Task Put(T Entity)
        {
            return _gen.Put(Entity);
        }

        public virtual Task Delete(T Entity)
        {
            return _gen.Delete(Entity);
        }
    }
}
