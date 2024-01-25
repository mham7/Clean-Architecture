using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppDbContext _context;
        public AdminRepo(AppDbContext context) {
            _context= context;
        }
        public List<Admin> IsSalaryGreater(int count) 
        {
            return _context.Admin.Where(admins => admins.Salary >count).ToList();
        }
    }
}
