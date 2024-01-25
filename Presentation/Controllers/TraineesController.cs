using Contouring_App.Application.Entities;
using Contouring_App.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly ITraineeService _traineeService;
        public TraineesController(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Trainee>>> GetAllTrainees()
        {
            if (_traineeService.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_traineeService.GetAll());
            }
        
        }

        [HttpGet("MinWage")]

        public async Task<ActionResult<List<Trainee>>> GetMinSalary(int salary)
        {
            return _traineeService.GetMinWage(salary);
        }

        [HttpPost("Add")]

        public async Task<ActionResult<Trainee>> AddTrainee(Trainee div)
        {
            if (div == null)
            {
                return BadRequest();
            }
            else
            {
                _traineeService.Add(div);
                return Ok(div);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Trainee>> DeleteTrainee(int id)
        {
            if (id != 0)
            {
                Trainee a = _traineeService.GetById(id);
                _traineeService.Delete(a);
                return Ok(a);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("Update")]

        public ActionResult<Division> UpdateTrainee(Trainee mang)
        {
            try
            {
                _traineeService.Update(mang);
                return Ok(mang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainee>> GetTrainee(int id)
        {
            Trainee a = _traineeService.GetById(id);
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
