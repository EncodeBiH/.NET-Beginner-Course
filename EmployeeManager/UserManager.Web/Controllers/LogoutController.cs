using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManager.BusinessLogic.Entities;

namespace UserManager.Web.Controllers;

public class LogoutController : Controller
{
    private readonly SignInManager<User> _signInManager;

    public LogoutController
    (
        SignInManager<User> signInManager
    )
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Login", "Login");
    }
}
