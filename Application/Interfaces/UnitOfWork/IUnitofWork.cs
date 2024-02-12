using Application.Interfaces.Repos;
using System;
using System.Collections.Generic;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
       
        IUserRepo users { get; }
        IGenericRepo<Type> _Generic { get; }
        Task SaveChanges();

    }
}
