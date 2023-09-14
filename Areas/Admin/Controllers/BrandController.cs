using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BrandController : Controller
{
    private readonly IBrandService brandService;

    public BrandController(IBrandService brandService)
    {
        this.brandService = brandService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetAllBrands()
    {
        var brands = this.brandService.FindAll();
        return Json(new { data = brands });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Brand payload)
    {
        var createdSuccess = this.brandService.Create(payload);
        if (createdSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Tạo nhãn hiệu thành công";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "ERROR|Tạo nhãn hiệu thất bại";
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {

        if (!id.HasValue)
        {
            return NotFound();
        }

        var brand = this.brandService.FindById(id.Value);
        return View(brand);
    }

    [HttpPost]
    public IActionResult Update(Brand payload)
    {
        var updatedSuccess = this.brandService.Update(payload);
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

        this.brandService.DeleteById(id.Value);
        return Json(new { success = true });
    }
}