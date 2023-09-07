using CellPhoneS.Areas.Admin.Models.EditModels;
using CellPhoneS.Areas.Admin.Models.ViewModels;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;
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
        var res = this.slideService.FindAll();

        var slides = new List<SlideViewModel>();

        foreach (var item in res)
        {
            slides.Add(
                new SlideViewModel
                {
                    Name = item.Name,
                    Id = item.Id,
                    Link = item.Link,
                    ThumbnailFilePath = item.ThumbnailFilePath,
                }
            );
        }

        return View(slides);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CreateSlide payload, IFormFile? fileThumbnail)
    {
        if (!ModelState.IsValid)
        {
            TempData["TOAST"] = "ERROR|Tạo slide không thành công";
            return View();
        }
        string[] thumbnails = new HandleFile("images/slide").Save(fileThumbnail);


        var createSlide = new Slide
        {
            Link = $"https://{payload.Link}",
            Name = payload.Name,
            Sort = payload.Sort,
            ThumbnailFileName = thumbnails[0],
            ThumbnailFilePath = thumbnails[1],
        };
        var createdSlideSuccess = this.slideService.Create(createSlide);


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
        var slideRes = this.slideService.FindById(id);

        var editSlide = new UpdateSlide
        {
            Id = slideRes.Id,
            Link = slideRes.Link.Substring(8),
            Name = slideRes.Name,
            Sort = slideRes.Sort,
            ThumbnailFileName = slideRes.ThumbnailFileName,
            ThumbnailFilePath = slideRes.ThumbnailFilePath,

        };

        return View(editSlide);
    }


    [HttpPost]
    public IActionResult Update(UpdateSlide payload, IFormFile? fileThumbnail)
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

        var updateSlide = new Slide
        {
            Id = payload.Id,
            Link = $"https://{payload.Link}",
            Name = payload.Name,
            Sort = payload.Sort,
            ThumbnailFileName = thumbnails[0],
            ThumbnailFilePath = thumbnails[1],
        };

        var updateSuccess = this.slideService.Update(updateSlide);
        if (!updateSuccess)
        {
            return View();
        }

        TempData["TOAST"] = "SUCCESS|Cập nhật thành công!";
        return RedirectToAction("Index");
    }

}