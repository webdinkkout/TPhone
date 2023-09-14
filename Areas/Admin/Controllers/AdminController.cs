using CellPhoneS.Common;
using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IHttpContextAccessor httpContextAccessor;
    public AdminController(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {

        return View();
    }

    [HttpGet("Admin/Login")]
    public IActionResult Login()
    {
        return View();
    }


    [HttpGet("Admin/Logout")]
    public IActionResult Logout()
    {
        return Redirect("/");
    }
}
