using Microsoft.AspNetCore.Mvc;
using TicketverkaufMM.Data;
using TicketverkaufMM.Models;
using TicketverkaufMM.ViewModels;

namespace TicketverkaufMM.Controllers
{
    public class ReservierungsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservierungsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservierungen = _context.Reservierungen
                .OrderBy(r => r.Datum)
                .ToList();
            return View(reservierungen);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ReservierungCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(ReservierungCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var reservierung = new Reservierung
            {
                Personenanzahl = vm.Personenanzahl,
                TischId = vm.TischId,
                EventName = vm.EventName,
                Datum = vm.Datum
            };

            _context.Reservierungen.Add(reservierung);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}