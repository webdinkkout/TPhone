using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}