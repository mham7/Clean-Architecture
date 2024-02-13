using Application.Interfaces.Repos;
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
    [ApiController]
    public class ProfilePicController : SuperController<ProfilePic, ProfilePicDto>
    {
        private readonly IGenericServices<ProfilePic> _gen;
        private readonly IMapper _mapper;
        public ProfilePicController(IGenericServices<ProfilePic> gen, IMapper mapper) : base(gen, mapper)
        {
            _mapper = mapper;
            _gen = gen;
        }

        [HttpPost("UploadImage")]
        [AllowAnonymous]
        public override async Task<ActionResult<ProfilePic>> Post([FromForm] ProfilePicDto a)
        {
            ProfilePic mappedEntity = _mapper.Map<ProfilePic>(a);
            await _gen.post(mappedEntity);
            return Ok(mappedEntity);


        }
    }
}
