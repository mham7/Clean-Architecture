using Application.Interfaces.Repos;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITraineeService:IGenericServices<Trainee>
    {
        Task<List<Trainee>> GetMinWageAsync(int salary);
    }
}
