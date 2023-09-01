using CellPhoneS.Areas.Admin.Models.ViewModels;
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
        var brandsRes = this.brandService.FindAll();

        var brands = new List<BrandViewModel>();

        foreach (var res in brandsRes)
        {
            brands.Add(new BrandViewModel { Id = res.Id, Name = res.Name, });
        }

        return View(brands);
    }

}