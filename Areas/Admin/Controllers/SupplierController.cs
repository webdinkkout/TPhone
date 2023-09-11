using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class SupplierController : Controller
{
    private readonly ISupplierService supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        this.supplierService = supplierService;
    }
    public IActionResult Index()
    {
        var suppliers = this.supplierService.FindAll();

        return View(suppliers);
    }

}