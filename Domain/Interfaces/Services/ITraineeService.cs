using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ITraineeService 
    {

        Task<Trainee> GetByIdAsync(int id);
        Task<IEnumerable<Trainee>> GetAllAsync();
        Task Add(Trainee trainee);
        Task Update(Trainee trainee);
        Task Delete(Trainee trainee);
        Task<List<Trainee>> GetMinWageAsync(int salary);
    }
}
