using Domain.Entities;

namespace Application.Interfaces.Repos
{
    public interface IAdminRepo :IGenericRepo<Admin>
    {
        public Task<List<Admin>> IsSalaryGreater(int count);
    }
}
