using Application.Interfaces.Repos;
using Domain.Entities;
using Domain.Entities.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TraineeRepo : GenericRepo<Trainee>,ITraineeRepo
    {
        private AppDbContext _dbContext;

        public TraineeRepo(AppDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Trainee>> GetTraineeswithMinWage(int salary)
        {
          IQueryable<Trainee> s= _dbContext.Trainee.Where(s=>s.Salary>salary);
            return await s.ToListAsync();
        }
    }
}
