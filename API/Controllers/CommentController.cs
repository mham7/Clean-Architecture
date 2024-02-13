using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : SuperController<PostComment, PostComment>
    {
        public CommentController(IGenericServices<PostComment> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
