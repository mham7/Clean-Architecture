using Domain.Entities;
using Domain.Interfaces;
using System;

namespace Domain.Interfaces
{
    public interface IAdminService
    {

        public Task<Admin> GetById(int id);
        public Task<IEnumerable<Admin>> GetAll();
        public Task Add(Admin admin);
        public Task Update(Admin admin);
        public Task Delete(Admin admin);
        public Task<List<Admin>> IsSalaryGreater(int salary);


    }
}
