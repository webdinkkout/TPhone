using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IProductService productService;
    private readonly IProductCategoryService productCategoryService;
    private readonly IBrandService brandService;
    private readonly ISupplierService supplierService;

    public ProductController(IProductService productService, IProductCategoryService productCategoryService, IBrandService brandService, ISupplierService supplierService)
    {
        this.productService = productService;
        this.productCategoryService = productCategoryService;
        this.brandService = brandService;
        this.supplierService = supplierService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var productCategories = this.productCategoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var brands = this.brandService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = suppliers;
        ViewBag.PRODUCT_CATEGORIES = productCategories;
        return View();
    }

    [HttpGet]
    public IActionResult GetAllProduct(int? categoryId, int? brandId, int? supplierId, string name = "")
    {
        var productsRes = this.productService.SearchProduct(categoryId, brandId, supplierId, name);
        return Json(productsRes);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        this.productService.DeleteById(id);

        return Json(new { success = true });
    }

    [HttpGet]
    public IActionResult Create()
    {
        var productCategories = this.productCategoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var brands = this.brandService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = suppliers;
        ViewBag.PRODUCT_CATEGORIES = productCategories;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product payload, IFormFile? fileThumbnail)
    {
        var thumbnails = new HandleFile("images/product").Save(fileThumbnail);

        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];

        var createdProductSuccess = this.productService.Create(payload);

        if (createdProductSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Tạo sản phẩm thành công";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "ERROR|Tạo sản phẩm thất bại";
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var editProduct = this.productService.FindById(id);

        if (editProduct == null)
        {
            return NotFound();
        }

        var productCategories = this.productCategoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var brands = this.brandService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = suppliers;
        ViewBag.PRODUCT_CATEGORIES = productCategories;
        return View(editProduct);
    }

    [HttpPost]
    public IActionResult Update(Product payload, IFormFile? fileThumbnail)
    {
        string[] thumbnails = new string[] { payload.ThumbnailFileName, payload.ThumbnailFilePath };
        if (fileThumbnail != null)
        {
            new HandleFile("images/product").Delete(thumbnails[0]);
            thumbnails = new HandleFile("images/product").Save(fileThumbnail);
        }

        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];

        var updatedProductSuccess = this.productService.Update(payload);
        if (!updatedProductSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Chỉnh sửa sản phẩm thành công";
        return RedirectToAction("Index");
    }

}