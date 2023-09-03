using CellPhoneS.Models.EditModels.Auth;
using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService authService;
    private readonly IUserService userService;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthController(IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        this.authService = authService;

        this.userService = userService;

        this.httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Login(Login payload)
    {

        var stateLogin = this.authService.Login(payload.Username, payload.Password);

        if (stateLogin == (int)LoginState.STRONG_EMAIL)
        {
            TempData["TOAST"] = "ERROR|Tên tài khoản không chính xác";
            return View();
        }

        if (stateLogin == (int)LoginState.STRONG_PASSWORD)
        {
            TempData["TOAST"] = "ERROR|Mật khẩu không chính xác";
            return View();
        }

        var userJson = JsonConvert.SerializeObject(this.userService.FindById(stateLogin));

        this.httpContextAccessor.HttpContext.Session.SetString("CURRENT_USER", userJson);
        return Redirect("/");
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Register payload)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        var newUser = new User
        {
            FirstName = payload.Firstname,
            LastName = payload.LastName,
            Password = payload.Password,
            Username = payload.Username
        };

        var isRegisterSuccess = this.authService.Register(newUser);

        if (!isRegisterSuccess)
        {
            return View();
        }

        return RedirectToAction("Login");
    }
}