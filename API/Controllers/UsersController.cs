
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
using API.Filters;

namespace Contouring_App.Presentation.Controllers
{
   
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ValidationFilter))]
    [Authorize]
    public class UsersController: SuperController<User,UserRegInfo>
    {
        private readonly IUserService _userService;

        public UsersController(IGenericServices<User> gen, IMapper mapper, IUserService userService) : base(gen, mapper)
        {
            _userService = userService;
        }


        [HttpGet("throw-exception")]
        [AllowAnonymous]
        public async Task ThrowException()
        {
            throw new ApplicationException("This is a test exception.");
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

        [HttpGet("Details/{id}")]
        public  async Task<ActionResult<User>>Get(int id)
        {
            return await _userService.Get(id);
        }




    }
}
