using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController : Controller
{
    private readonly IBrandRepository brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        this.brandRepository = brandRepository;
    }

    public IActionResult Index()
    {
        var brands = this.brandRepository.FindAll();

        return View(brands);
    }

}