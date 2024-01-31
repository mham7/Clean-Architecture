using Domain.Entities;
using Domain.Interfaces.Repos;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AdminRepo : GenericRepo<Admin>, IAdminRepo
    {
        private readonly AppDbContext _context;
        public AdminRepo(AppDbContext context) :base(context) 
        {
            _context= context;
        }
        public async Task<List<Admin>> IsSalaryGreater(int count) 
        {
            return await _context.Admin.Where(admins => admins.Salary >count).ToListAsync();
        }
    }
}
