using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Controllers;

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
}
