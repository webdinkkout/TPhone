using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;


[Area("Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        var isLogged = true;
        if (!isLogged)
        {
            return RedirectToAction("Login");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        var isLogged = true;
        if (isLogged)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
