using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class RoleController : Controller
{
    private readonly IRoleService roleService;

    public RoleController(IRoleService roleService)
    {
        this.roleService = roleService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetAllRoles()
    {
        var roles = this.roleService.FindAll();
        return Json(new { data = roles });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Role payload)
    {
        var createdSuccess = this.roleService.Create(payload);
        if (createdSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Tạo cấp bật thành công";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "ERROR|Tạo cấp bật thất bại";
        return View();
    }

    [HttpGet]
    public IActionResult Edit(string? id)
    {

        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var role = this.roleService.FindByStrId(id);
        return View(role);
    }

    [HttpPost]
    public IActionResult Update(Role payload)
    {
        var updatedSuccess = this.roleService.Update(payload);
        if (updatedSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Chỉnh sửa thành công!";
            return RedirectToAction("Index");
        }
        TempData["TOAST"] = "ERROR|Chỉnh sửa thất bại!";
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (!id.HasValue)
        {
            return Json(new { success = false });
        }

        this.roleService.DeleteById(id.Value);
        return Json(new { success = true });
    }

}