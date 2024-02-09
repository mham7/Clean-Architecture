using Infrastructure.Repositories;
using Infrastructure.Context;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;


namespace Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _appcontext;
        public IAdminRepo admins { get; }

        public static readonly Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
        public IDevRepo devs { get; }
        public IGenericRepo<Type> _Generic { get; }
        public IManagerRepo managers { get; }

        public ITraineeRepo trainees { get; }

        public IDivisionRepo divs { get; }

        public IUserRepo users { get; }

      
        public UnitofWork(AppDbContext appcontext, IAdminRepo adminrepo,
         IDevRepo devrepo, IManagerRepo managerrepo,IGenericRepo<Type> Generic,ITraineeRepo traineerepo, IDivisionRepo divrepo,IUserRepo userrepo)
        {
            _appcontext = appcontext;
            admins = adminrepo;
            devs=devrepo;
            managers = managerrepo;
            trainees = traineerepo;
            divs = divrepo;
            users = userrepo;
            _Generic = Generic;
           
        }

  

        public void Dispose()
        {
            _appcontext.Dispose();
        }

        public async Task SaveChanges()
        {
            await _appcontext.SaveChangesAsync();
        }
    }
}
