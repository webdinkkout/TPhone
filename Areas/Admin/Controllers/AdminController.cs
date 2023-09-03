using CellPhoneS.Areas.Admin.Models.EditModels.Auth;
using CellPhoneS.Common;
using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CellPhoneS.Areas.Admin.Controllers;


[Area("Admin")]
public class AdminController : Controller
{
    private readonly IAuthService authService;
    private readonly IUserService userService;
    private readonly IHttpContextAccessor httpContextAccessor;
    public AdminController(IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        this.authService = authService;
        this.userService = userService;
        this.httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
        var currentUser = UserLogin.GetCurrentUser(this.httpContextAccessor);
        if (currentUser == null)
        {
            return RedirectToAction("Login");
        }

        if (currentUser?.RoleId != "ADMIN")
        {
            return RedirectToAction("Login");
        }

        return View();
    }

    [HttpGet("Admin/Login")]
    public IActionResult Login()
    {
        var currentUser = UserLogin.GetCurrentUser(this.httpContextAccessor);
        if (currentUser != null)
        {
            if (currentUser?.RoleId == "ADMIN")
            {
                return RedirectToAction("Index");
            }
        }

        return View();
    }


    [HttpPost("Admin/Login")]
    public IActionResult Login(Login payload)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        var stateLogin = this.authService.LoginAdmin(payload.Username, payload.Password);

        if (stateLogin == (int)LoginState.STRONG_EMAIL)
        {
            TempData["TOAST"] = "ERROR|Email không hợp lệ!";
            return View();
        }
        if (stateLogin == (int)LoginState.STRONG_PASSWORD)
        {
            TempData["TOAST"] = "ERROR|Password không hợp lệ!";
            return View();
        }

        if (stateLogin == (int)LoginState.AUTH)
        {
            TempData["TOAST"] = "ERROR|Tài khoản chưa được kích hoạt vui lòng liên hệ ADMIN để biết thêm chi tiết";
            return View();
        }
        var user = this.userService.FindById(stateLogin);
        var userLoginJson = JsonConvert.SerializeObject(user);
        this.httpContextAccessor.HttpContext?.Session.SetString("CURRENT_USER", userLoginJson);
        TempData["TOAST"] = "SUCCESS|Đăng nhập thành công";
        return RedirectToAction("Index");
    }

    [HttpGet("Admin/Logout")]
    public IActionResult Logout()
    {

        var currentUser = UserLogin.GetCurrentUser(this.httpContextAccessor);
        if (currentUser == null)
        {
            TempData["TOAST"] = "ERROR|Đã xảy ra lỗi vui lòng liên hệ ADMIN để báo lỗi! Trân trọng";
            return View();
        }

        this.httpContextAccessor.HttpContext?.Session.Remove("CURRENT_USER");
        return Redirect("/");
    }
}
