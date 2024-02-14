
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Dtos;
using Domain.Models;
using API.Controllers;
using AutoMapper;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: SuperController<User,UserRegInfo>
    {
        private readonly IUserService _userService;

        public UsersController(IGenericServices<User> gen, IMapper mapper, IUserService userService) : base(gen, mapper)
        {
            _userService = userService;
        }
       


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromBody] Userdto div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok( await _userService.Post(div));

            }
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public override async Task<ActionResult<User>> Post([FromBody]UserRegInfo div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
               return Ok (await _userService.Post(div));
                
            }
        }

       


    }
}
