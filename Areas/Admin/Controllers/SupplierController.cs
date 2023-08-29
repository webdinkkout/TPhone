using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class SupplierController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}