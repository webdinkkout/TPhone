using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CellPhoneS.Models;

namespace CellPhoneS.Controllers;

public class AuthController : Controller
{
    private readonly IAuthRepository authRepository;
    private readonly IUserRepository userRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthController(IAuthRepository authRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        this.authRepository = authRepository;

        this.userRepository = userRepository;

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

        var stateLogin = this.authRepository.Login(payload.Username, payload.Password);

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

        var userJson = JsonConvert.SerializeObject(this.userRepository.FindById(stateLogin));

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

        if (!ModelState.IsValid)
        {
            return View();
        }


        var isRegisterSuccess = this.authRepository.Register(payload);

        if (!isRegisterSuccess)
        {
            return View();
        }

        return RedirectToAction("Login");
    }
}