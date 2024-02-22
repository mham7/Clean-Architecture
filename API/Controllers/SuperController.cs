﻿using API.Filters;
using Application.Interfaces.Repos;
using Application.Interfaces.Services.Utlities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class SuperController<T,X> : ControllerBase where T : class where X: class
    {
        private readonly  IGenericServices<T> _gen;
        private readonly IMapper _mapper;

        public SuperController(IGenericServices<T> gen, IMapper mapper)
        {
            _gen = gen;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await _gen.Get();
        }

        
        [HttpGet("{id}")]
        public virtual async Task<T> Get(int id)
        {
            return await _gen.Get(id);
        }


        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody] X entity)
        {
            T mappedEntity = _mapper.Map<T>(entity);
            await _gen.post(mappedEntity);
            return Ok( mappedEntity);
        }


        [HttpPut("{id}")]
        public async Task<T> Put(T entity)
        {
            
            await _gen.Put(entity);
            return entity;

        }

        
        [HttpDelete("{id}")]
        public async Task<T> Delete(int id)
        {
            T entity = await _gen.Get(id);
            await _gen.Delete(entity);
            return entity;

        }
    }
}
