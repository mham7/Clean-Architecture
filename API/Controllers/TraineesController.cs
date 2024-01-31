using Domain.Entities;
using Domain.Entities.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class TraineesController(ITraineeService traineeService) : ControllerBase
    {
        private readonly ITraineeService _traineeService = traineeService;

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Trainee>>> GetAllTrainees()
        {
            if (await _traineeService.GetAllAsync() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _traineeService.GetAllAsync());
            }
        
        }

        [HttpGet("MinWage")]

        public async Task<ActionResult<List<Trainee>>> GetMinSalary(int salary)
        {
            return await _traineeService.GetMinWageAsync(salary);
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
               await _traineeService.Add(div);
                return Ok(div);
            }
        }

        [HttpDelete("Delete")]

        public async Task<ActionResult<Trainee>> DeleteTrainee(int id)
        {
            if (id != 0)
            {
                Trainee a = await _traineeService.GetByIdAsync(id);
                await _traineeService.Delete(a);
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
            Trainee a = await _traineeService.GetByIdAsync(id);
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
