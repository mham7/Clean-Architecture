using Application.Interfaces.Repos;
using System;
using System.Collections.Generic;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
        IAdminRepo admins { get; }
        IDevRepo devs { get; }
        ITraineeRepo trainees { get; }
        IDivisionRepo divs { get; }
        IUserRepo users { get; }
        IManagerRepo managers { get; }
        Task SaveChanges();

    }
}
