using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Components;

public class SlideAccessoryBottomViewComponent : ViewComponent
{
    private readonly IProductService productService;

    public SlideAccessoryBottomViewComponent(IProductService productService)
    {
        this.productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync() => View(this.productService.FindAll().Where(x => x.ProductCategoryId == 3).OrderBy(x => x.CreatedAt).ToList());
}