using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductCategoryController : Controller
{
    private readonly IProductCategoryService productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        this.productCategoryService = productCategoryService;
    }

    [HttpGet("Admin/ProductCategories")]
    public IActionResult Index()
    {
        var categories = this.productCategoryService.FindAll();
        return View(categories);
    }

    [HttpGet("Admin/ProductCategories/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Admin/ProductCategories/Create")]
    public IActionResult Create(ProductCategory payload, IFormFile? fileThumbnail)
    {
        TempData["TOAST"] = "ERROR|Tạo danh mục không thành công";
        if (!ModelState.IsValid)
        {
            return View();
        }
        var isCreatedSuccess = this.productCategoryService.Create(payload, fileThumbnail);
        if (!isCreatedSuccess)
        {
            return View();
        }
        TempData["TOAST"] = "SUCCESS|Tạo danh mục thành công";
        return RedirectToAction("Index");

    }

    [HttpGet("Admin/ProductCategories/Edit/{id?}")]
    public IActionResult Edit(int id)
    {
        var productCategory = this.productCategoryService.FindById(id);

        if (productCategory == null)
        {
            return RedirectToAction("Index");
        }

        return View(productCategory);
    }

    [HttpPost("Admin/ProductCategories/Update/{id?}")]
    public IActionResult Update(ProductCategory payload, IFormFile? fileThumbnail)
    {
        TempData["TOAST"] = "ERROR|Chỉnh sửa không thành công";
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit", new { id = payload.Id });
        }

        if (fileThumbnail != null)
        {
            new HandleFile("images/category").Delete(payload.ThumbnailFilePath.Split('/').Last());
        }

        string[] thumbnailAttr = new HandleFile("images/category").Save(fileThumbnail!);
        string seoName = HandleSeoName.GenerateSEOName(payload.Name);

        payload.SeoName = seoName;
        payload.ThumbnailFileName = thumbnailAttr[0];
        payload.ThumbnailFilePath = thumbnailAttr[1];

        var isUpdatedSuccess = this.productCategoryService.Update(payload);
        if (!isUpdatedSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Đã chỉnh sửa thành công";
        return RedirectToAction("Index");
    }

    [HttpGet("Admin/ProductCategories/Delete/{id?}")]
    public IActionResult Delete(int id)
    {
        var isDeletedSuccess = this.productCategoryService.DeleteById(id);

        if (!isDeletedSuccess)
        {
            TempData["TOAST"] = "ERROR|xóa không thành công";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "SUCCESS|Đã xóa thành công";
        return RedirectToAction("Index");

    }
}
