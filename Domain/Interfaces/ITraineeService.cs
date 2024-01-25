using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface ITraineeService
    {

        public Trainee GetById(int id);
        public IEnumerable<Trainee> GetAll();
        public void Add(Trainee trainee);
        public void Update(Trainee trainee);
        public void Delete(Trainee trainee);
        public List<Trainee> GetMinWage(int salary);
    }
}
