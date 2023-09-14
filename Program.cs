using System.Text.Json.Serialization;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddSingleton<IEmailSender, MailService>();


builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Connect Db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDatabase") != null ? builder.Configuration.GetConnectionString("ConnectDatabase") : "Server=.;Database=CellPhonesDb;Integrated Security=true;TrustServerCertificate=True");
    // options.UseSqlServer("Server=localhost,1433;Database=CellPhonesDb;User Id=sa;Password=878645436TaiLe; TrustServerCertificate=true");
});

// Config Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

// builder.Services.AddDefaultIdentity<AppUser>()
//                 .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
                                        {
                                            options.LoginPath = "/Login";
                                            options.AccessDeniedPath = "/khong-co-quyen-truy-cap.html";
                                        });

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configs Password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;

    // Configs Lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Config User.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

    // Config Login.
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

});

// Add DI
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISlideService, SlideService>();
builder.Services.AddScoped<IMenuService, MenuService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromSeconds(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapRazorPages();
app.MapControllerRoute(
      name: "areasRoute",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{slug?}"
    );

using (var scope = app.Services.CreateScope())
{
    await DataSeeders.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.Run();
