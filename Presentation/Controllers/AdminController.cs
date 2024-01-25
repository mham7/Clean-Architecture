using Contouring_App.Application.Entities;
using Contouring_App.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Admin>>> GetAllAdmins()
        {
            if (_adminService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_adminService.GetAll());
            }
        }

        [HttpPost("Add")]

        public async Task<ActionResult<Admin>> Add(Admin admin)
        {
            if (admin == null)
            {
                return BadRequest();
            }
            else
            {
                _adminService.Add(admin);
                return Ok(admin);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Admin>> DeleteAdmin(int id)
        {
            if (id != 0)
            {
                Admin a = _adminService.GetById(id);
                _adminService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]

        public ActionResult<Admin> UpdateAdmin(Admin admin)
        {
            try
            {
                _adminService.Update(admin);
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            Admin a= _adminService.GetById(id);
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
