using Domain.Entities;

namespace Domain.Interfaces.Repos
{
    public interface IAdminRepo :IGenericRepo<Admin>
    {
        public Task<List<Admin>> IsSalaryGreater(int count);
    }
}
