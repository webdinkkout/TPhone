using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CellPhoneS.Models;

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
    public IActionResult Login(User payload)
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
    public IActionResult Register(User payload)
    {


        var isRegisterSuccess = this.authService.Register(payload);

        if (!isRegisterSuccess)
        {
            return View();
        }

        return RedirectToAction("Login");
    }
}