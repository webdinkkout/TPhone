using System.Text.Json.Nodes;
using CellPhoneS.Areas.Admin.Models.EditModels.Menu;
using CellPhoneS.Areas.Admin.Models.ViewModels;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
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
    public IActionResult Create(CreateMenu payload)
    {

        var createMenu = new Menu
        {
            Title = payload.Title,
            Description = payload.Description,
            Position = payload.Position,
        };

        this.menuService.Create(createMenu);

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

        var editMenu = new UpdateMenu
        {
            Id = menu.Id,
            Title = menu.Title,
            Description = menu.Description,
            Position = menu.Position,
            Alias = menu.Alias,
        };

        return View(editMenu);
    }

    [HttpPost]
    public IActionResult Update(UpdateMenu payload)
    {
        var updatedMenu = new Menu
        {
            Id = payload.Id,
            Title = payload.Title,
            Description = payload.Description,
            Position = payload.Position,
            Alias = payload.Alias
        };

        this.menuService.Update(updatedMenu);

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