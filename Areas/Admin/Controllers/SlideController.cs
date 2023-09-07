using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Areas.Admin.Controllers;

[Area("Admin")]
public class SlideController : Controller
{
    private readonly ISlideService slideService;

    public SlideController(ISlideService slideService)
    {
        this.slideService = slideService;
    }


    [HttpGet]
    public IActionResult Index()
    {
        var slides = this.slideService.FindAll();

        return View(slides);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Slide payload, IFormFile? fileThumbnail)
    {
        if (!ModelState.IsValid)
        {
            TempData["TOAST"] = "ERROR|Tạo slide không thành công";
            return View();
        }
        string[] thumbnails = new HandleFile("images/slide").Save(fileThumbnail);


        payload.Link = $"https://{payload.Link}";
        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];
        var createdSlideSuccess = this.slideService.Create(payload);

        if (!createdSlideSuccess)
        {
            TempData["TOAST"] = "ERROR|Tạo slide không thành công";
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Tạo slide thành công";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var deletedSlideSuccess = this.slideService.DeleteById(id);
        if (!deletedSlideSuccess)
        {
            TempData["TOAST"] = "ERROR|Xóa thất bại";
            return RedirectToAction("Index");
        }

        TempData["TOAST"] = "SUCCESS|Xóa thành công";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var slide = this.slideService.FindById(id);
        return View(slide);
    }


    [HttpPost]
    public IActionResult Update(Slide payload, IFormFile? fileThumbnail)
    {
        TempData["TOAST"] = "ERROR|Cập nhật thất bại";

        if (!ModelState.IsValid)
        {
            return View();
        }


        string[] thumbnails = new string[] { payload.ThumbnailFileName, payload.ThumbnailFilePath };
        if (fileThumbnail != null)
        {
            new HandleFile("/images/slide").Delete(thumbnails[0]);
            new HandleFile("/images/slide").Save(fileThumbnail);
        }

        payload.Link = $"https://{payload.Link}";
        payload.ThumbnailFileName = thumbnails[0];
        payload.ThumbnailFilePath = thumbnails[1];

        var updateSuccess = this.slideService.Update(payload);
        if (!updateSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Cập nhật thành công!";
        return RedirectToAction("Index");
    }

}