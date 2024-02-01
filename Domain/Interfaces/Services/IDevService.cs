using Domain.Entities;
namespace Domain.Interfaces.Services
{
    public interface IDevService:IGenericServices<Dev>
    {
        Task<List<Dev>> getStacklist(string ts);
    }
}
