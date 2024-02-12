using Application.Interfaces.Repos;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperController<T> : ControllerBase where T : class
    {
        private readonly  IGenericServices<T> _gen;
        public SuperController(IGenericServices<T> gen)
        {
            _gen = gen;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await _gen.Get();
        }

        
        [HttpGet("{id}")]
        public async Task<T> Get(int id)
        {
            return await Get(id);
        }

       
        [HttpPost]
        public async Task Post(T entity)
        {
             await _gen.Post(entity);
        }

        
        [HttpPut("{id}")]
        public async Task<T> Put(T entity)
        {
            
            await _gen.Put(entity);
            return entity;

        }

        
        [HttpDelete("{id}")]
        public async Task<T> Delete(int id)
        {
            T entity = await _gen.Get(id);
            await _gen.Delete(entity);
            return entity;

        }
    }
}
