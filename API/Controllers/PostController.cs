using API.Filters;
using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class PostController : SuperController<Post, PostDto>
    {
        public PostController(IGenericServices<Post> gen, IMapper mapper) : base(gen, mapper)
        {
        }


        public override Task<ActionResult<Post>> Post([FromForm] PostDto entity)
        {
            return base.Post(entity);
        }
    }



}
