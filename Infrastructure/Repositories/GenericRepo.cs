using System.Linq;
using System.Collections.Generic;
using Infrastructure.Context;

using Application.Interfaces.Repos;

namespace Infrastructure.Repositories

{
    public abstract class GenericRepo<T>(AppDbContext appcontext) : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _appContext = appcontext;

        public virtual async Task<T> Get(int id)
        {
            T entity = await  _appContext.Set<T>().FindAsync(id);
            return entity ?? throw new Exception("Data is nulll");
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            IEnumerable<T> all_data = await _appContext.Set<T>().ToListAsync();
            return all_data ?? throw new Exception("Data is nulll");
        }

        public virtual async Task Post(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Put(T entity)
        {
             _appContext.Set<T>().Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
           await SaveChanges();
        }
        public virtual async Task SaveChanges()
        {
           await _appContext.SaveChangesAsync();
        }
    }

}
