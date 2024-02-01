using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repos;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;

namespace Contouring_App.Application.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly IUnitofWork _unit;
        public TraineeService(IUnitofWork unit)
        {
            _unit = unit;
        }
        public async Task Add(Trainee trainee)
        {
           await _unit.trainees.Add(trainee);
        }

        public async Task Delete(Trainee trainee)
        {
            await _unit.trainees.Delete(trainee);
        }

        public async Task<List<Trainee>> GetMinWageAsync(int salary)
        {
            return await _unit.trainees.GetTraineeswithMinWage(salary);
        }

        public async Task<IEnumerable<Trainee>> GetAll()
        {
            return await _unit.trainees.GetAll();
        }

        public async Task<Trainee> GetById(int id)
        {
            return await _unit.trainees.GetById(id);
        }

        public async Task Update(Trainee trainee)
        {
             await _unit.trainees.Update(trainee);
        }
    }
}
