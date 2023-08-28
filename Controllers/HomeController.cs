using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
