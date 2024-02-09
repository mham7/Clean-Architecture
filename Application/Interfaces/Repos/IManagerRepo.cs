using Domain.Entities;
using Domain.Entities.Dtos;

namespace Application.Interfaces.Repos
{
    public interface IManagerRepo:IGenericRepo<Manager>
    {
        Task<List<Divlist>> GetTraineesUnderManager(Manager manager);
    }
}
