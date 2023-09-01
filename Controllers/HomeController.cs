using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Controllers;

public class HomeController : Controller
{
    private readonly IProductService productService;

    public HomeController(IProductService productService)
    {
        this.productService = productService;
    }

    public IActionResult Index()
    {
        var products = this.productService.FindAll().OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.UpdatedAt).Take(4).ToList();
        return View(products);
    }
}
