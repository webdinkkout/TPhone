using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly IProductCategoryRepository productCategoryRepository;
    private readonly IBrandRepository brandRepository;
    private readonly ISupplierRepository supplierRepository;

    public ProductController(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IBrandRepository brandRepository, ISupplierRepository supplierRepository)
    {
        this.productRepository = productRepository;
        this.productCategoryRepository = productCategoryRepository;
        this.brandRepository = brandRepository;
        this.supplierRepository = supplierRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var productCategories = this.productCategoryRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var brands = this.brandRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = suppliers;
        ViewBag.PRODUCT_CATEGORIES = productCategories;
        return View();
    }

    [HttpGet]
    public IActionResult GetAllProduct(int? categoryId, int? brandId, int? supplierId, string name = "")
    {
        var productsRes = this.productRepository.SearchProduct(categoryId, brandId, supplierId, name);
        return Json(productsRes);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        this.productRepository.DeleteById(id);

        return Json(new { success = true });
    }

    [HttpGet]
    public IActionResult Create()
    {
        var productCategories = this.productCategoryRepository.FindAll();

        var brands = this.brandRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = brands;
        return View(productCategories);
    }

    [HttpPost]
    public IActionResult Create(Product payload, IFormFile? fileThumbnail)
    {

        TempData["TOAST"] = "ERROR|Tạo sản phẩm thất bại";

        if (!ModelState.IsValid)
        {

            return View();
        }
        var thumbnails = new HandleFile("images/product").Save(fileThumbnail);

        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];

        var createdProductSuccess = this.productRepository.Create(payload);

        if (createdProductSuccess)
        {
            TempData["TOAST"] = "SUCCESS|Tạo sản phẩm thành công";
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var editProduct = this.productRepository.FindById(id);

        if (editProduct == null)
        {
            return NotFound();
        }

        var productCategories = this.productCategoryRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var brands = this.brandRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        var suppliers = this.supplierRepository.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        ViewBag.BRANDS = brands;
        ViewBag.SUPPLIERS = suppliers;
        ViewBag.PRODUCT_CATEGORIES = productCategories;
        return View(editProduct);
    }

    [HttpPost]
    public IActionResult Update(Product payload, IFormFile? fileThumbnail)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        string[] thumbnails = new string[] { payload.ThumbnailFileName, payload.ThumbnailFilePath };
        if (fileThumbnail != null)
        {
            new HandleFile("images/product").Delete(thumbnails[0]);
            thumbnails = new HandleFile("images/product").Save(fileThumbnail);
        }

        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];

        var updatedProductSuccess = this.productRepository.Update(payload);
        if (!updatedProductSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Chỉnh sửa sản phẩm thành công";
        return RedirectToAction("Index");
    }

}