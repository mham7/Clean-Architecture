using Application.Interfaces.Repos;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ManagerRepo : GenericRepo<Manager>,IManagerRepo
    {

        private AppDbContext _dbContext;

        public ManagerRepo(AppDbContext context):base(context) 
        {
            _dbContext = context;
        }
       
        public List<string> GetCommonDivisions(Manager manager) 
        {
            throw new NotImplementedException();
        }
    }
}
