using Domain.Entities;
using Domain.Entities.Dtos;

namespace Application.Interfaces.Repos
{
    public interface IManagerRepo:IGenericRepo<Manager>
    {
        public List<string> GetCommonDivisions(Manager manager);
    }
}
