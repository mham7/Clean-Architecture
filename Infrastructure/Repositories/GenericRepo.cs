using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Dtos;
using Infrastructure.Context;
using Domain.Interfaces.Repos;

namespace Infrastructure.Repositories

{
    public class GenericRepo<T>(AppDbContext appcontext) : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _appContext = appcontext;

        public async Task<T> GetById(int id)
        {
            T entity = await  _appContext.Set<T>().FindAsync(id);
            return entity ?? throw new Exception("Data is nulll");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> all_data = await _appContext.Set<T>().ToListAsync();
            return all_data ?? throw new Exception("Data is nulll");
        }

        public async Task Add(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public async Task Update(T entity)
        {
             _appContext.Set<T>().Update(entity);
            await SaveChanges();
        }

        public async Task Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
           await SaveChanges();
        }
        public async Task SaveChanges()
        {
           await _appContext.SaveChangesAsync();
        }
    }

}
