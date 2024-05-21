using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManager.BusinessLogic.BussinessLogicService.UserService;
using UserManager.BusinessLogic.Entities;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly IUserService _userService;
    private readonly SignInManager<User> _signInManager;

    public LoginController
    (
        IUserService userService,
        SignInManager<User> signInManager
    )
    {
        _userService = userService;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel request)
    {
        var user = _userService.GetByEmail(request.Email);

        if (user is null)
        {
            TempData["Error"] = "Email or password is not correct.";
            return View();
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);

        if (!signInResult.Succeeded)
        {
            TempData["Error"] = "Email or password is not correct.";
            return View();
        }

        return RedirectToAction("Index", "Employee");
    }
}
