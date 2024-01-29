using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitofWork : IDisposable
    {
        IAdminRepo admins { get; }
        IDevRepo devs { get; }
        IManagerRepo managers { get; }
        ITraineeRepo trainees { get; }
        IDivisionRepo divs { get; }
        IUserRepo users { get; }
        Task SaveChanges();
        
    }
}
