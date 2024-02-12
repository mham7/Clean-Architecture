using Application.Interfaces.Repos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatController : SuperController<User>
    {
        public UserChatController(IGenericServices<User> gen) : base(gen)
        {
        }
    }
}
