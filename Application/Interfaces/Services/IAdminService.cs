using Domain.Entities;
using System;

namespace Application.Interfaces.Repos
{
    public interface IAdminService:IGenericServices<Admin>
    {   
        Task<List<Admin>> GetAdminsByLocation(string location);

    }
}
