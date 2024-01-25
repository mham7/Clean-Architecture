using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface ITraineeRepo
    {
        public List<Trainee> GetTraineeswithMinWage(int salary);


    }
}
