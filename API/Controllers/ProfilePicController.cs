using API.Filters;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class ProfilePicController : SuperController<ProfilePic, ProfilePicDto>
    {
        private readonly IGenericServices<ProfilePic> _gen;
        private readonly IMapper _mapper;
        private readonly IProfilePicService _prof;
        public ProfilePicController(IGenericServices<ProfilePic> gen, IMapper mapper,IProfilePicService prof) : base(gen, mapper)
        {
            _mapper = mapper;
            _gen = gen;
            _prof = prof;
        }

        [HttpPost("UploadImage")]
        [AllowAnonymous]
        public override async Task<ActionResult<ProfilePic>> Post([FromForm] ProfilePicDto a)
        {
            ProfilePic v=await _prof.Post(a);
            return v;

        }
    }
}
