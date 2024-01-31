using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repos
{
    public interface ITraineeRepo:IGenericRepo<Trainee>
    {
        public Task<List<Trainee>> GetTraineeswithMinWage(int salary);


    }
}
