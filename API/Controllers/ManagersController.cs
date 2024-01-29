using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces;
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
            if (await _mangservice.GetAllAsync() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _mangservice.GetAllAsync());
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
               await _mangservice.Add(div);
                return Ok(div);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Manager>> DeleteManager(int id)
        {
            if (id != 0)
            {
                Manager a = await _mangservice.GetById(id);
                await _mangservice.Delete(a);
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
            Manager a = await _mangservice.GetById(id);
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
