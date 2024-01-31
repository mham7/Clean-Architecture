using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class DevsController(IDevService devService) : ControllerBase
    {

        private readonly IDevService _devService = devService;

    
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Dev>>> GetAllDevs()
        {
            
            if (await _devService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _devService.GetAll());
            }
        }

        [HttpGet("GetStacks")]
        public async Task<ActionResult<List<Dev>>> GetStackDevs(string techstack)
        {
            if (await _devService.getStacklist(techstack) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _devService.getStacklist(techstack));
            }
        }

        [HttpPost("Add")]

        public async Task<ActionResult<Dev>> AddDev(Dev dev)
        {
            if (dev == null)
            {
                return BadRequest();
            }
            else
            {
               await _devService.Add(dev);
                return Ok(dev);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Dev>> DeleteDev(int id)
        {
            if (id != 0)
            {
                Dev a = await _devService.GetById(id);
                await _devService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]

        public ActionResult<Dev> UpdateDev(Dev dev)
        {
            try
            {
                _devService.Update(dev);
                return Ok(dev);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Dev>> GetDev(int id)
        {
            Dev a = await _devService.GetById(id);
            if (a == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(a);
            }
        }

        //Pagination
        //[HttpGet("GetDevPages")]
        //public async Task<ActionResult<List<Dev>>> GetDevPages([FromQuery] int page = 1, [FromQuery] int per_page = 5)
        //{
        //    var devs = _devService.GetAll();

        //    if (devs == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        var pagedDevs = devs.Skip((page - 1) * per_page).Take(per_page).ToList();
        //        return Ok(pagedDevs);
        //    }
        //}
    }
}

