using CellPhoneS.Areas.Admin.Models.ViewModels;
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
        var suppliersRes = this.supplierService.FindAll();
        var suppliers = new List<SupplierViewModel>();

        foreach (var res in suppliersRes)
        {
            suppliers.Add(
                new SupplierViewModel { Id = res.Id, Address = res.Address, Email = res.Email, Name = res.Name, PhoneNumber = res.PhoneNumber }
            );
        }
        return View(suppliers);
    }

}