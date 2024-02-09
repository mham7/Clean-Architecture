using Application.Interfaces.Repos;
using Domain.Entities;
using Domain.Entities.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ManagerRepo : GenericRepo<Manager>,IManagerRepo
    {

        private AppDbContext _dbContext;

        public ManagerRepo(AppDbContext context):base(context) 
        {
            _dbContext = context;
        }
       
        public async Task<List<Divlist>> GetTraineesUnderManager(Manager manager) 
        {
            IQueryable<Divlist> trainee = _dbContext.Trainee.Where(x => x.Division_id ==manager.Division_id).Select(x => new Divlist { Divid = x.Division_id, Name = x.Name, role = "Trainee" });
            List<Divlist> a = await trainee.ToListAsync();
            return a;
        }

    }
}
