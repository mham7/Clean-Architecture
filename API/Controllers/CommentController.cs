using Application.Interfaces.Repos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : SuperController<PostComment>
    {
        public CommentController(IGenericServices<PostComment> gen) : base(gen)
        {
        }
    }
}
