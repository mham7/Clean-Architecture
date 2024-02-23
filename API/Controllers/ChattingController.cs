using API.Filters;
using Application.Interfaces.Repos;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Utlities;
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
    [Authorize]
    public class ChatController : SuperController<UserChat, UserChat>
    {
        private readonly IUserChatService _UserChatService;
        private readonly IMessagingService _MessagingService;
        private readonly IClaimsService _Claims;
        public ChatController(IGenericServices<UserChat> gen, IMapper mapper,
            IUserChatService userChatService, IMessagingService MessagingService,IClaimsService Claims) : base(gen, mapper)
        {
            _UserChatService = userChatService;
            _MessagingService = MessagingService;
            _Claims = Claims;
        }

        //Send Message
        [HttpPost("Message")]
        public async Task<Message> Post(MessageDto dto)
        {
            //dto.senderID = _Claims.GetUserID(User);
           return  await _UserChatService.Post(dto);
        }

        //Get All messages in a chat
        [HttpGet("Inbox/{id}")]
        [Authorize]
        public async Task<List<Message>> GetChat(int id)
        {
            int userId = _Claims.GetUserID(User);
            return await _UserChatService.Get(userId, id);
            
        }

        //Get Messenger list
        [HttpGet("Messenger")]
        [Authorize]
        public new async Task<List<ChatDto>> Get()
        {
            int userId = _Claims.GetUserID(User);
            return await _UserChatService.GetInbox(userId);
        }

        //remove userchat from the user. The id is chatid
        [HttpPut("UserChat/{id}")]
        [Authorize]
        public async Task<UserChat> Put(int id)
        {
            int userId = _Claims.GetUserID(User);
           return await _UserChatService.Put(id,userId);
     
        }

        //Deleting Messages
        [HttpDelete("Message/{id}")]
        [Authorize]
        public async Task<Message> DeleteMessage(int id)
        {
            int userId = _Claims.GetUserID(User);
            return await _UserChatService.Delete(userId,id);
        }

        //Editing Message
        [HttpPatch("Message/{id}")]
        [Authorize]
        public async Task<string> Patch(int id,string message)
        {
           return await _MessagingService.Patch(id, message);
        }
    }
}
