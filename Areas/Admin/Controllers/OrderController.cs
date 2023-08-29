using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}