using API.Filters;
using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class CommunityController : SuperController<Community, CommunityDto>
    {
        public CommunityController(IGenericServices<Community> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
