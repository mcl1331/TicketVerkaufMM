using Microsoft.AspNetCore.Mvc;
using TicketverkaufMM.ViewModels;

namespace TicketverkaufMM.Controllers
{
    public class ReservierungsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ReservierungCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(ReservierungCreateViewModel vm)
        {
            if(!ModelState.IsValid)
                return View(vm);
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
