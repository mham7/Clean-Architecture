
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Dtos;
using Domain.Models;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsercss()
        {
            if (await _userService.Get() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _userService.Get());
            }
        }



        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> SigninUser([FromBody] Userdto div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok( await _userService.Login(div));

            }
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> AddUsercs(UserRegInfo div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
               return Ok (await _userService.Register(div));
                
            }
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<ActionResult<User>> DeleteUsercs(int id)
        {
            if (id != 0)
            {
                User a = await _userService.Get(id);
               await _userService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]
        [Authorize]
        public async Task<ActionResult<User>> UpdateUsercs(User mang)
        {
            try
            {
               await _userService.Put(mang);
                return Ok(mang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User a = await _userService.Get(id);
            if (a == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(a);
            }
        }
    }
}
