using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class NavController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}