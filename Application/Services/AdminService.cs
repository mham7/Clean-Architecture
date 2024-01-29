using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
namespace Contouring_App.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitofWork _unit;
        private readonly IGenericRepo<Admin> _gen;

        public AdminService(IGenericRepo<Admin> gen,IUnitofWork unit)
        {
            _unit= unit;
            _gen= gen;
        }
        public async Task Add(Admin admin)
        {
           await _gen.Add(admin);    
        }

        public async Task Delete(Admin admin)
        {
            await _gen.Delete(admin);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
           return await _gen.GetAll();
        }

        public async Task<Admin> GetById(int id)
        {
            Admin admin = await _gen.GetById(id);
            return admin;
        }

        public async Task<List<Admin>> IsSalaryGreater(int salary)
        {
            return await _unit.admins.IsSalaryGreater(salary);

        }

        public async Task Update(Admin admin)
        {
           await _gen.Update(admin);
        }
    }
}
