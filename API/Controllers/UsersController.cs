using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsercss()
        {
            if (await _userService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _userService.GetAll());
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
                return Ok( await _userService.Login(div));

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
               return Ok (await _userService.Register(div));
                
            }
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<ActionResult<Usercs>> DeleteUsercs(int id)
        {
            if (id != 0)
            {
                Usercs a = await _userService.GetById(id);
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
        public async Task<ActionResult<Usercs>> UpdateUsercs(Usercs mang)
        {
            try
            {
               await _userService.Update(mang);
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
            Usercs a = await _userService.GetById(id);
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
