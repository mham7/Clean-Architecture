using Contouring_App.Application.Entities;
using Contouring_App.Application.Entities.Dtos;
using Contouring_App.Application.Services;
using Contouring_App.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisonService;
        public DivisionController(IDivisionService divisionService)
        {
            _divisonService = divisionService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Division>>> GetAllDivs()
        {
            if (_divisonService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_divisonService.GetAll());
            }
        }


        [HttpGet("GetEmployeeDivisions")]

        public async Task<ActionResult<List<Divlist>>> GetEmpDivs(int div_id)
        {
           return _divisonService.GetDivisions(div_id);
        }
        [HttpPost("Add")]

        public async Task<ActionResult<Division>> AddDev(Division div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                _divisonService.Add(div);
                return Ok(div);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Division>> DeleteDiv(int id)
        {
            if (id != 0)
            {
                Division a = _divisonService.GetById(id);
                _divisonService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]

        public ActionResult<Division> UpdateDiv(Division div)
        {
            try
            {
                _divisonService.Update(div);
                return Ok(div);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> GetDiv(int id)
        {
            Division a = _divisonService.GetById(id);
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
