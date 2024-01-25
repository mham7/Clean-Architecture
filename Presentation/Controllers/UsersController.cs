using Contouring_App.Application.Entities;
using Contouring_App.Application.Entities.Dtos;
using Contouring_App.Application.Services;
using Contouring_App.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) { _userService = userService; }

      

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsercss()
        {
            if (_userService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_userService.GetAll());
            }
        }



        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<Usercs>> SigninUser([FromBody] Userdto div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_userService.Login(div));

            }
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<Usercs>> AddUsercs(Usercs div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
               return Ok (_userService.Register(div));
                
            }
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<ActionResult<Usercs>> DeleteUsercs(int id)
        {
            if (id != 0)
            {
                Usercs a = _userService.GetById(id);
                _userService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]
        [Authorize]
        public async Task<ActionResult<Usercs>> UpdateUsercs(Usercs mang)
        {
            try
            {
                _userService.Update(mang);
                return Ok(mang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usercs>> GetUsercs(int id)
        {
            Usercs a = _userService.GetById(id);
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
