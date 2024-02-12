using Application.Interfaces.Repos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : SuperController<Chats>
    {
        public ChatController(IGenericServices<Chats> gen) : base(gen)
        {
        }
    }
}
