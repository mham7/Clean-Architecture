using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : SuperController<Post, Post>
    {
        public PostController(IGenericServices<Post> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
