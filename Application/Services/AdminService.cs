using Domain.Entities;
using Domain.Interfaces.Repos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
namespace Contouring_App.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitofWork _unit;
        

        public AdminService(IUnitofWork unit)
        {
            _unit= unit;
        }
        public async Task Add(Admin admin)
        {
           await _unit.admins.Add(admin);    
        }

        public async Task Delete(Admin admin)
        {
            await _unit.admins.Delete(admin);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
           return await _unit.admins.GetAll();
        }

        public async Task<Admin> GetById(int id)
        {
            Admin admin = await _unit.admins.GetById(id);
            return admin;
        }

        public async Task<List<Admin>> IsSalaryGreater(int salary)
        {
            return await _unit.admins.IsSalaryGreater(salary);

        }

        public async Task Update(Admin admin)
        {
           await _unit.admins.Update(admin);
        }
    }
}
