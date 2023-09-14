using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}