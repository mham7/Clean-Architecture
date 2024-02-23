
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
using System.Security.Claims;

namespace Contouring_App.Presentation.Controllers
{
   
    [Route("api/[controller]")]
    [ValidationFilter]
    [GlobalExceptionFilter]
    [Authorize]
    public class UsersController: SuperController<User,UserInfo>
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
        public async Task<ActionResult<User>> Post([FromBody]UserRegInfo div)
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
        public async Task<ActionResult<User>>Get(int id)
        {
            return await _userService.Get(id);
        }

        [HttpPatch("UpdateInfo")]
        public async Task<ActionResult<string>> patch(Userdto cred)
        {
             var userclaim=User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userclaim.Value);
            return await _userService.Patch(userId, cred);
        }

    }
}
