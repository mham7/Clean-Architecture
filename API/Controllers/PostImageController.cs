using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostImageController : SuperController<PostImage, PostImageDto>
    {
        public PostImageController(IGenericServices<PostImage> gen, IMapper mapper) : base(gen, mapper)
        {

        }
    }
}
