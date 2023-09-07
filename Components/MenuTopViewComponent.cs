using CellPhoneS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CellPhoneS.Components;

public class MenuTopViewComponent : ViewComponent
{
    private readonly IMenuRepository menuRepository;

    public MenuTopViewComponent(IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync() => View(this.menuRepository.FindAll().OrderBy(x => x.Position).ToList());
}