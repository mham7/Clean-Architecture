﻿using System.Linq;
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

        public async Task<T> GetById(int id)
        {
            T entity = await  _appContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Data is nulll");
            }

            return entity;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> all_data = await _appContext.Set<T>().ToListAsync();
            if (all_data == null)
            {
                throw new Exception("Data is nulll");
            }
            return all_data;

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
