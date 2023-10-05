using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AboutController : Controller
{
    private readonly IAboutService aboutService;

    public AboutController(IAboutService aboutService)
    {
        this.aboutService = aboutService;
    }

    public IActionResult Index()
    {

        var about = this.aboutService.FindById(1);

        return View(about);
    }
    public IActionResult Edit()
    {
        var about = this.aboutService.FindById(1);
        return View(about);
    }

    public IActionResult Update(About about)
    {
        this.aboutService.Update(about);
        TempData["TOAST"] = "SUCCESS|Chỉnh sửa thành công";
        return RedirectToAction("Edit");
    }

}