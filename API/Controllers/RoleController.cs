using API.Filters;
using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class RoleController : SuperController<Role, RoleDto>
    {
        public RoleController(IGenericServices<Role> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
