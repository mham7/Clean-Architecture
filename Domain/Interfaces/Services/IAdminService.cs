using Domain.Entities;
using System;

namespace Domain.Interfaces.Services
{
    public interface IAdminService:IGenericServices<Admin>
    {   
        public Task<List<Admin>> IsSalaryGreater(int salary);


    }
}
