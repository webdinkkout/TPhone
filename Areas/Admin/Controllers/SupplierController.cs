using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class SupplierController : Controller
{
    private readonly ISupplierRepository supplierRepository;

    public SupplierController(ISupplierRepository supplierRepository)
    {
        this.supplierRepository = supplierRepository;
    }
    public IActionResult Index()
    {
        var suppliers = this.supplierRepository.FindAll();

        return View(suppliers);
    }

}