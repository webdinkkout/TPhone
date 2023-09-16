using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SupplierController : Controller
{
    private readonly ISupplierService supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        this.supplierService = supplierService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetAllSuppliers()
    {
        var suppliers = this.supplierService.FindAll();
        return Json(new { data = suppliers });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Supplier payload)
    {
        var createdSuccess = this.supplierService.Create(payload);
        if (createdSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Tạo nhà sản cung cấp thành công";
            return RedirectToAction("Index");
        }
        TempData["TOAST"] = "SUCCESS|Tạo nhà sản cung cấp thất bại";
        return View();
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }
        var supplier = this.supplierService.FindById(id.Value);
        return View(supplier);
    }

    [HttpPost]
    public IActionResult Update(Supplier payload)
    {

        var updatedSuccess = this.supplierService.Update(payload);
        if (updatedSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Chỉnh sửa nhà sản cung cấp thành công";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "SUCCESS|Chỉnh sửa nhà sản cung cấp thất bại";
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (!id.HasValue)
        {
            return Json(new { success = false });
        }

        this.supplierService.DeleteById(id.Value);
        return Json(new { success = true });
    }
}