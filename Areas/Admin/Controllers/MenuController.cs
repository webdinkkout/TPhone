using System.Text.Json.Nodes;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class MenuController : Controller
{
    private readonly IMenuService menuService;

    public MenuController(IMenuService menuService)
    {
        this.menuService = menuService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var menus = this.menuService.FindAll();
        return View(menus);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Menu payload)
    {

        this.menuService.Create(payload);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }
        var menu = this.menuService.FindById(id.Value);
        return View(menu);
    }

    [HttpPost]
    public IActionResult Update(Menu payload)
    {
        this.menuService.Update(payload);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id.HasValue)
        {
            this.menuService.DeleteById(id.Value);
        }

        return Json(new { success = true });
    }

}