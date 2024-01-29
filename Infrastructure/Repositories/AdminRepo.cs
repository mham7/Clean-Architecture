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
        public async Task<List<Admin>> IsSalaryGreater(int count) 
        {
            return await _context.Admin.Where(admins => admins.Salary >count).ToListAsync();
        }
    }
}
