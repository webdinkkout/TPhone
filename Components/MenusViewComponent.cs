using CellPhoneS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CellPhoneS.Components;

public class MenusViewComponent : ViewComponent
{
    private readonly ApplicationDbContext dbContext;

    public MenusViewComponent(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync() => View(await this.dbContext.Menus.ToListAsync());
}