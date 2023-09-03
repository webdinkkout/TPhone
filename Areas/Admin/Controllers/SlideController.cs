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
            Link = payload.Link,
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

}