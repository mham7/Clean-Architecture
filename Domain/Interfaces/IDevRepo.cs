using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDevRepo
    {
        public Task<List<Dev>> GetStackList(string techstack);
    }
}
