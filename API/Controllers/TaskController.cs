using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : SuperController<Tasks,TskDto>
    {
        public TaskController(IGenericServices<Tasks> gen, IMapper mapper) : base(gen, mapper)
        {

        }

        [HttpPost("Assign")]
        public async Task Create([FromBody] TskDto dto)
        {
           await Post(dto);
        }
    }
}
