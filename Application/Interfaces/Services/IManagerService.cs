using Domain.Entities;
using Domain.Entities.Dtos;

namespace Application.Interfaces.Repos
{
    public interface IManagerService :IGenericServices<Manager>
    {
        Task<List<Divlist>> TraineesAssignedToManager(Manager manager);
      




    }
}
