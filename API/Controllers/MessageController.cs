using Application.Interfaces.Repos;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : SuperController<Message, Message>
    {
        public MessageController(IGenericServices<Message> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
