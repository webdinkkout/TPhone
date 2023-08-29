using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class FeedbackController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}