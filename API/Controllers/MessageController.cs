using Application.Interfaces.Repos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : SuperController<Message>
    {
        public MessageController(IGenericServices<Message> gen) : base(gen)
        {
        }
    }
}
