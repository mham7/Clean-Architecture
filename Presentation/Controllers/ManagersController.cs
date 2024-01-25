using Contouring_App.Application.Entities;
using Contouring_App.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _mangservice;
        public ManagersController(IManagerService managerService) {
        _mangservice=managerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {
            if (_mangservice.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mangservice.GetAll());
            }
        }

        [HttpPost("Add")]

        public async Task<ActionResult<Manager>> AddManager(Manager div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                _mangservice.Add(div);
                return Ok(div);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Manager>> DeleteManager(int id)
        {
            if (id != 0)
            {
                Manager a = _mangservice.GetById(id);
                _mangservice.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]

        public ActionResult<Division> UpdateManager(Manager mang)
        {
            try
            {
                _mangservice.Update(mang);
                return Ok(mang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            Manager a = _mangservice.GetById(id);
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
