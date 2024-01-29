using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Contouring_App.Application.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly IUnitofWork _unit;
        private readonly IGenericRepo<Trainee> _gen;
        public TraineeService(IUnitofWork unit, IGenericRepo<Trainee> gen)
        {
            _unit = unit;
            _gen = gen;
        }
        public async Task Add(Trainee trainee)
        {
           await _gen.Add(trainee);
        }

        public async Task Delete(Trainee trainee)
        {
            await _gen.Delete(trainee);
        }

        public async Task<List<Trainee>> GetMinWageAsync(int salary)
        {
            return await _unit.trainees.GetTraineeswithMinWage(salary);
        }

        public async Task<IEnumerable<Trainee>> GetAllAsync()
        {
            return await _gen.GetAll();
        }

        public async Task<Trainee> GetByIdAsync(int id)
        {
            return await _gen.GetById(id);
        }

        public async Task Update(Trainee trainee)
        {
             await _gen.Update(trainee);
        }
    }
}
