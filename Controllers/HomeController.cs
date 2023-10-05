using CellPhoneS.Interfaces;
using CellPhoneS.Models;
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

    public IActionResult Detail(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var product = productService.FindById(id.Value);

        var relationProducts = productService.FindProductByCategoryId(product.ProductCategoryId).Where(x => x.Id != id.Value).ToList();

        if (product == null)
        {
            return NotFound();
        }


        ViewBag.RELATION_PRODUCTS = relationProducts;
        return View(product);
    }

    public IActionResult Product()
    {
        return View();
    }

    public IActionResult Category()
    {
        return View();
    }

    public IActionResult SearchProduct(string key)
    {
        List<Product> products = productService.SearchAllProduct(key);
        return Json(new { data = products });
    }
}
