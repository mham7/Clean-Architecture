using Domain.Entities;


namespace Application.Interfaces.Repos
{
    public interface IDevRepo:IGenericRepo<Dev>
    {
        public Task<List<Dev>> GetStackList(string techstack);
    }
}
