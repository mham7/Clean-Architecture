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
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class CommentController : SuperController<PostComment, PostCommentDto>
    {
        public CommentController(IGenericServices<PostComment> gen, IMapper mapper) : base(gen, mapper)
        {

        }
    }
}
