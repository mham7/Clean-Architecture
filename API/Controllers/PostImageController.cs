using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostImageController : SuperController<PostImage, PostImage>
    {
        public PostImageController(IGenericServices<PostImage> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
