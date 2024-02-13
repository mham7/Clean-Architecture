using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommunityController : SuperController<Community, CommunityDto>
    {
        public CommunityController(IGenericServices<Community> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
