﻿using Domain.Entities;
using Domain.Entities.Dtos;
using Application.Interfaces.Repos;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contouring_App.Presentation.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class ManagersController(IManagerService managerService) : ControllerBase
    {
        private readonly IManagerService _mangservice = managerService;

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {
            if (await _mangservice.GetAll() == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _mangservice.GetAll());
            }
        }



        [HttpGet("TraineesUnderManager")]
        public async Task<ActionResult<List<Divlist>>> GetTraineesAssignedToManager(Manager mang) { 
            
            return await _mangservice.TraineesAssignedToManager(mang);
        
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

        public async Task<ActionResult<Division>> UpdateManager(Manager mang)
        {
            try
            {
                await _mangservice.Update(mang);
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
