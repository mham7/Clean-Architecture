using Domain.Entities;
using System;

namespace Application.Interfaces.Repos
{
    public interface IAdminService:IGenericServices<Admin>
    {   
        public Task<List<Admin>> IsSalaryGreater(int salary);


    }
}
