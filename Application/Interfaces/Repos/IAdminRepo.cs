using Domain.Entities;

namespace Application.Interfaces.Repos
{
    public interface IAdminRepo :IGenericRepo<Admin>
    {
        Task<List<Admin>> GetAdminbyOfficeLocation(string location);
    }
}
