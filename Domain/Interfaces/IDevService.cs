using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IDevService
    {
        public Dev GetById(int id);
        public IEnumerable<Dev> GetAll();
        public List<Dev> getstacklist(string ts);
        public void Add(Dev dev);
        public void Update(Dev dev);
        public void Delete(Dev dev);
    }
}
