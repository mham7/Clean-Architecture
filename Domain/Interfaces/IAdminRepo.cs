using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAdminRepo
    {
        public List<Admin> IsSalaryGreater(int count);
    }
}
