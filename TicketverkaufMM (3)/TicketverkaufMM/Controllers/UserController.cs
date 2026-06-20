using Microsoft.AspNetCore.Mvc;

namespace TicketverkaufMM.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
