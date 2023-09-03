using CellPhoneS.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Components;

public class UserInfoViewComponent : ViewComponent
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserInfoViewComponent(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentUserJson = this.httpContextAccessor.HttpContext.Session.GetString("CURRENT_USER");
        User user = new User();
        if (currentUserJson != null)
        {
            user = JsonConvert.DeserializeObject<User>(currentUserJson);

        }
        return View(user);
    }
}