

using TicketverkaufMM.Models;
using Microsoft.AspNetCore.Identity; 

using Microsoft.AspNetCore.Mvc; 

using TicketverkaufMM.ViewModels; 

 

namespace TicketverkaufMM.Controllers;



public class AccountController : Controller

{

    private readonly SignInManager<User> _signInManager;

    private readonly UserManager<User> _userManager;



    public AccountController(SignInManager<User> signInManager,

                              UserManager<User> userManager)

    {

        _signInManager = signInManager;

        _userManager = userManager;

    }



    [HttpGet]

    public IActionResult Login() => View();



    [HttpPost]

    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Login(LoginViewModel model)

    {

        if (!ModelState.IsValid) return View(model);



        var result = await _signInManager.PasswordSignInAsync(

            model.Email, model.Password,

            isPersistent: false, lockoutOnFailure: false);



        if (result.Succeeded)

            return RedirectToAction("Index", "Home");



        ModelState.AddModelError(string.Empty, "Ungültiger Login-Versuch.");

        return View(model);

    }



    [HttpGet]

    public IActionResult Register() => View();



    [HttpPost]

    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Register(RegisterViewModel model)

    {

        if (!ModelState.IsValid) return View(model);



        var user = new User { UserName = model.Email, Email = model.Email };

        var result = await _userManager.CreateAsync(user, model.Password);



        if (result.Succeeded)

        {

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");

        }



        foreach (var error in result.Errors)

            ModelState.AddModelError(string.Empty, error.Description);



        return View(model);

    }



    public async Task<IActionResult> Logout()

    {

        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");

    }



    public IActionResult AccessDenied() =>

        Content("Zugriff verweigert. Notwendige Rechte fehlen.");

}