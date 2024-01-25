using Domain.Entities;
using Domain.Interfaces;
using System;

namespace Domain.Interfaces
{
    public interface IAdminService
    {

        public Admin GetById(int id);
        public IEnumerable<Admin> GetAll();
        public void Add(Admin admin);
        public void Update(Admin admin);
        public void Delete(Admin admin);
        public List<Admin> IsSalaryGreater(int salary);


    }
}
