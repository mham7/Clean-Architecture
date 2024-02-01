using Domain.Entities;
using Application.Interfaces.Repos;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class DevRepo : GenericRepo<Dev>,IDevRepo
    {
        private readonly AppDbContext _appDbContext;

        public DevRepo(AppDbContext appDbContext):base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Dev>> GetStackList(string techstack)
        {
            List<Dev> result = new List<Dev>();
             IQueryable<Dev> techstck = _appDbContext.Devs.Where(d => d.Techstack == techstack);
            result=  await techstck.ToListAsync();
            return result;
        }
    }
}
