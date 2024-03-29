﻿using Domain.Entities;
using Domain.Entities.Dtos;
namespace Application.Interfaces.Repos
{
    public interface IGenericRepo<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
