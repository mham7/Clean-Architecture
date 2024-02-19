using API.Filters;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
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
    public class MessageController : SuperController<Message, Message>
    {
        private readonly IMessagingService _msg;
        public MessageController(IGenericServices<Message> gen, IMapper mapper,IMessagingService msg) : base(gen, mapper)
        {
            _msg = msg;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult<Message>> Post(MessageDto a)
        {
          
               return Ok(await _msg.Post(a));
            
            
        }

        [HttpGet("GetChat")]
        public async Task<ActionResult<List<Message>>> Get(int Chatid)
        {
            List<Message> msg= await _msg.Get(Chatid);
            return Ok(msg);
        }
    }
}
