using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface ITraineeService
    {

        public Task<Trainee> GetByIdAsync(int id);
        public Task<IEnumerable<Trainee>> GetAllAsync();
        public Task Add(Trainee trainee);
        public Task Update(Trainee trainee);
        public Task Delete(Trainee trainee);
        public Task<List<Trainee>> GetMinWageAsync(int salary);
    }
}
