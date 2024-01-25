using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories

{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _appContext;

        public GenericRepo(AppDbContext appcontext)
        {
            _appContext = appcontext;
        }

        public T GetById(int id)
        {
            T entity = _appContext.Set<T>().Find(id);
            if (entity == null)
            {
                throw new Exception("Data is nulll");
            }

            return entity;

        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> all_data = _appContext.Set<T>().ToList();
            if (all_data == null)
            {
                throw new Exception("Data is nulll");
            }
            return all_data;

        }

        public void Add(T entity)
        {
            _appContext.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            _appContext.Set<T>().Update(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
    }

}
