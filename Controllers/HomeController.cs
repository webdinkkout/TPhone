using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository productRepository;

    public HomeController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = this.productRepository.FindAll().OrderByDescending(x => x.CreatedAt).ThenByDescending(x => x.UpdatedAt).Take(4).ToList();
        return View(products);
    }
}
