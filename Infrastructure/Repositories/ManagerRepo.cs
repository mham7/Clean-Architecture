using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Repos;
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
