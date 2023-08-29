using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}