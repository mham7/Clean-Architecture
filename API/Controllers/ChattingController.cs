using API.Filters;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Services;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ValidationFilter]
    [GlobalExceptionFilter]
    [ApiController]
    public class ChatController : SuperController<UserChat, UserChat>
    {
        private readonly IUserChatService _UserChatService;
        private readonly IMessagingService _MessagingService;
        public ChatController(IGenericServices<UserChat> gen, IMapper mapper,IUserChatService userChatService, IMessagingService MessagingService) : base(gen, mapper)
        {
            _UserChatService = userChatService;
            _MessagingService = MessagingService;
        }

        //Send Message
        [HttpPost("Message")]
        public async Task<Message> Post(MessageDto dto)
        {
           return  await _UserChatService.Post(dto);
        }

        //Get All messages in a chat
        [HttpGet("Inbox/{id}")]
        public async Task<List<Message>> GetChat(int id)
        {
            return await _MessagingService.GetInbox(id);
        }

        //Get Messenger list
        [HttpGet("Messenger")]
        [Authorize]
        public async Task<List<ChatDto>> Get()
        {
            var userclaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userclaim.Value);
            
            return await _UserChatService.GetInbox(userId);
        }

        //Deleting remove userid from uchat chat and messages, If 
        [HttpDelete("{id}")]
        [Authorize]
        public override async Task<UserChat> Delete(int id)
        {
            return null; 
        }

        //Deleting Messages
        [HttpDelete("Message/{id}")]
        [Authorize]
        public async Task<string> Delete(int ChatId,int id)
        {
            Message msg= await _MessagingService.Get(id);
            await _MessagingService.Delete(msg);
            return "Deleted";
        }

        //Editing Message
        [HttpPatch("Message/{id}")]
        [Authorize]
        public async Task<string> Patch(int id)
        {
            return "z";
        }
    }
}
