using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ITraineeService:IGenericServices<Trainee>
    {
        Task<List<Trainee>> GetMinWageAsync(int salary);
    }
}
