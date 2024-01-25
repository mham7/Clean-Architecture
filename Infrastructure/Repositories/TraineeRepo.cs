using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TraineeRepo : ITraineeRepo
    {
        private AppDbContext _dbContext;

        public TraineeRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Trainee> GetTraineeswithMinWage(int salary)
        {
          IQueryable<Trainee> s= _dbContext.Trainee.Where(s=>s.Salary>salary);
            return s.ToList();
        }
    }
}
