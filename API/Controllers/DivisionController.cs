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
    public class DivisionController : SuperController<Division, DivDto>
    {
        public DivisionController(IGenericServices<Division> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
