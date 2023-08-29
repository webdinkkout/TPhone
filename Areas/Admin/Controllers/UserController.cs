using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }

}