using Domain.Entities;

namespace Domain.Interfaces.Repos
{
    public interface IDevRepo:IGenericRepo<Dev>
    {
        public Task<List<Dev>> GetStackList(string techstack);
    }
}
