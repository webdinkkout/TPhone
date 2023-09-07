using System.Text.Json.Nodes;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class MenuController : Controller
{
    private readonly IMenuRepository menuRepository;

    public MenuController(IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var menus = this.menuRepository.FindAll();
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

        this.menuRepository.Create(payload);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }
        var menu = this.menuRepository.FindById(id.Value);
        return View(menu);
    }

    [HttpPost]
    public IActionResult Update(Menu payload)
    {
        this.menuRepository.Update(payload);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id.HasValue)
        {
            this.menuRepository.DeleteById(id.Value);
        }

        return Json(new { success = true });
    }

}