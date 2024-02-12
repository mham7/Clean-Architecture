using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
