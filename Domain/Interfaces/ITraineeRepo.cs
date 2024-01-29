using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface ITraineeRepo
    {
        public Task<List<Trainee>> GetTraineeswithMinWage(int salary);


    }
}
