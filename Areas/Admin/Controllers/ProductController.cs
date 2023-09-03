using CellPhoneS.Areas.Admin.Models.EditModels.Product;
using CellPhoneS.Areas.Admin.Models.ViewModels;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;
using CellPhoneS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
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
        var categories = this.productCategoryService.FindAll();
        var brands = this.brandService.FindAll();
        var suppliers = this.supplierService.FindAll();

        var productViewModel = new ProductViewModel
        {
            ProductCategories = categories,
            Brands = brands,
            Suppliers = suppliers
        };

        return View(productViewModel);
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

        return Json(new { OK = true });
    }

    [HttpGet]
    public IActionResult Create()
    {
        var productCategories = this.productCategoryService.FindAll();
        var brands = this.brandService.FindAll();
        var suppliers = this.supplierService.FindAll();
        var createProduct = new CreateProduct
        {
            ProductCategories = productCategories,
            Brands = brands,
            Suppliers = suppliers
        };

        return View(createProduct);
    }

    [HttpPost]
    public IActionResult Create(CreateProduct payload, IFormFile? fileThumbnail)
    {

        TempData["TOAST"] = "ERROR|Tạo sản phẩm thất bại";

        if (!ModelState.IsValid)
        {

            return View();
        }
        var thumbnails = new HandleFile("images/product").Save(fileThumbnail);
        var createProduct = new Product
        {
            ProductName = payload.ProductName,
            Price = payload.Price,
            PromotionPrice = payload.PromotionPrice,
            Quantity = payload.Quantity,
            IsHot = payload.IsHot,
            Desc = payload.Desc,
            ContentHtml = payload.ContentHtml,
            ProductCategoryId = payload.ProductCategoryId,
            BrandId = payload.BrandId,
            SupplierId = payload.SupplierId,
            ThumbnailFileName = thumbnails[0],
            ThumbnailFilePath = thumbnails[1]
        };

        var createdProductSuccess = this.productService.Create(createProduct);

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
        var editProduct = this.productService.FindById(id);

        if (editProduct == null)
        {
            return NotFound();
        }

        var categories = this.productCategoryService.FindAll();
        var brands = this.brandService.FindAll();
        var suppliers = this.supplierService.FindAll();

        var editProductView = new UpdateProduct
        {
            Id = editProduct.Id,
            Desc = editProduct.Desc,
            BrandId = editProduct.BrandId,
            ContentHtml = editProduct.ContentHtml,
            IsHot = editProduct.IsHot,
            Price = editProduct.Price,
            ProductCategoryId = editProduct.ProductCategoryId,
            ProductName = editProduct.ProductName,
            PromotionPrice = editProduct.PromotionPrice,
            Quantity = editProduct.Quantity,
            SupplierId = editProduct.SupplierId,
            ThumbnailFileName = editProduct.ThumbnailFileName,
            ThumbnailFilePath = editProduct.ThumbnailFilePath,

            ProductCategories = categories,
            Brands = brands,
            Suppliers = suppliers,
        };

        return View(editProductView);
    }

    [HttpPost]
    public IActionResult Update(UpdateProduct payload, IFormFile? fileThumbnail)
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


        var editProduct = new Product
        {
            Id = payload.Id,
            Desc = payload.Desc,
            BrandId = payload.BrandId,
            ContentHtml = payload.ContentHtml,
            IsHot = payload.IsHot,
            Price = payload.Price,
            ProductCategoryId = payload.ProductCategoryId,
            ProductName = payload.ProductName,
            PromotionPrice = payload.PromotionPrice,
            Quantity = payload.Quantity,
            SupplierId = payload.SupplierId,
            ThumbnailFileName = thumbnails[0],
            ThumbnailFilePath = thumbnails[1]
        };


        var updatedProductSuccess = this.productService.Update(editProduct);
        if (!updatedProductSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Chỉnh sửa sản phẩm thành công";
        return RedirectToAction("Index");
    }

}