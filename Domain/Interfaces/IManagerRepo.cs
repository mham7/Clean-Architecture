
using Domain.Entities;
using Domain.Entities.Dtos;

namespace Domain.Interfaces.Repositories
{
    public interface IManagerRepo
    {
        public List<string> getCommonDivisions(Manager manager); 
    }
}
