using Domain.Entities;
using Domain.Entities.Dtos;
using Application.Interfaces.Repos;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class DivisionRepo : GenericRepo<Division>,IDivisionRepo
    {
        private readonly AppDbContext _context;

        public DivisionRepo(AppDbContext context):base(context)
        {
             _context = context;
        }
        public async Task <List<Divlist>> Get_Trainees_ManagersByDivID(int division)
        {
            IQueryable<Divlist> manager =  _context.Manager.Where(x => x.Division_id == division).Select(x => new Divlist { Divid = x.Division_id, Name = x.Name , role="Manager" });
            IQueryable<Divlist> trainee =  _context.Trainee.Where(x => x.Division_id == division).Select(x => new Divlist { Divid = x.Division_id, Name = x.Name, role = "Trainee" });
            List<Divlist> a=await manager.ToListAsync();
            List<Divlist> b=await trainee.ToListAsync();

            IEnumerable<Divlist> result = a.Concat(b);

            return result.ToList();
        }
    }
}
