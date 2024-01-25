using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDevRepo
    {
        public List<Dev> GetStackList(string techstack);
    }
}
