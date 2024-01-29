using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAdminRepo
    {
        public Task<List<Admin>> IsSalaryGreater(int count);
    }
}
