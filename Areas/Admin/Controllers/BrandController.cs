using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController : Controller
{
    private readonly IBrandService brandService;

    public BrandController(IBrandService brandService)
    {
        this.brandService = brandService;
    }

    public IActionResult Index()
    {
        var brands = this.brandService.FindAll();

        return View(brands);
    }

}