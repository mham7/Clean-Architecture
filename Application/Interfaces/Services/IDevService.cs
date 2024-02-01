using Domain.Entities;
namespace Application.Interfaces.Repos
{
    public interface IDevService:IGenericServices<Dev>
    {
        Task<List<Dev>> getStacklist(string ts);
    }
}
