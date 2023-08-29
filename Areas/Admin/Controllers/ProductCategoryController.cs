using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CellPhoneS.Models.DomainModels;

using CellPhoneS.Areas.Admin.Models.EditModels;
using CellPhoneS.Areas.Admin.Models.ViewModels;
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
        var categoriesViewModel = new List<CategoryViewModel>();

        var categoriesRes = this.productCategoryService.FindAll();

        foreach (var item in categoriesRes)
        {
            categoriesViewModel.Add(new CategoryViewModel(item.Id, item.Name, item.SeoName, item.ThumbnailFilePath));
        }

        return View(categoriesViewModel);
    }

    [HttpGet("Admin/ProductCategories/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Admin/ProductCategories/Create")]
    public IActionResult Create(CreateProductCategory payload, IFormFile? fileThumbnail)
    {
        TempData["TOAST"] = "ERROR|Tạo danh mục không thành công";
        if (!ModelState.IsValid)
        {
            return View();
        }

        var newProductCategory = new ProductCategory
        {
            Name = payload.Name,
            ThumbnailFileName = "",
            ThumbnailFilePath = "",
        };
        var isCreatedSuccess = this.productCategoryService.Create(newProductCategory, fileThumbnail);
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
        var productCategoryRes = this.productCategoryService.FindById(id);

        if (productCategoryRes == null)
        {
            return RedirectToAction("Index");
        }

        var productCategory = new EditProductCategory
        {
            Id = productCategoryRes.Id,
            Name = productCategoryRes.Name,
            ThumbnailFilePath = productCategoryRes.ThumbnailFilePath,
        };

        return View(productCategory);
    }

    [HttpPost("Admin/ProductCategories/Update/{id?}")]
    public IActionResult Update(EditProductCategory payload, IFormFile? fileThumbnail)
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

        var updateProductCategory = new ProductCategory
        {
            Id = payload.Id,
            Name = payload.Name,
            ThumbnailFileName = fileThumbnail != null ? thumbnailAttr[0] : payload?.ThumbnailFilePath?.Split('/').Last(),
            ThumbnailFilePath = fileThumbnail != null ? thumbnailAttr[1] : payload?.ThumbnailFilePath,
            SeoName = seoName
        };

        var isUpdatedSuccess = this.productCategoryService.Update(updateProductCategory);
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
