using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// hinzufuegen
using TicketverkaufMM.ViewModels;

namespace TicketverkaufMM.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Login Versuch
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Ungültiger Login-Versuch");
        }
        // Bei Fehler view neu anzeigen (Validation Summary zeigt Fehler)
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Einfache AccessDenied Anzeige
    public IActionResult AccessDenied()
    {
        return Content("Zugriff verweigert. Notwendige Rechte fehlen");
    }
}
