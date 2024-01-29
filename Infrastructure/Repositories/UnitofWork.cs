using Infrastructure.Repositories;
using Infrastructure.Context;
using Domain.Interfaces.Repositories;


namespace Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _appcontext;

        public IAdminRepo admins { get; }

        public IDevRepo devs { get; }

        public IManagerRepo managers { get; }

        public ITraineeRepo trainees { get; }

        public IDivisionRepo divs { get; }

        public IUserRepo users { get; }
        public UnitofWork(AppDbContext appcontext, IAdminRepo adminrepo,
         IDevRepo devrepo, IManagerRepo managerrepo,ITraineeRepo traineerepo, IDivisionRepo divrepo,IUserRepo userrepo)
        {
            _appcontext = appcontext;
            admins = adminrepo;
            devs=devrepo;
            managers = managerrepo;
            trainees = traineerepo;
            divs = divrepo;
            users = userrepo;
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
