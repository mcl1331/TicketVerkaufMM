using Microsoft.AspNetCore.Mvc;

namespace TicketverkaufMM.Controllers;

public class EventController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
