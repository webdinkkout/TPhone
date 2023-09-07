using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect Db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDatabase") != null ? builder.Configuration.GetConnectionString("ConnectDatabase") : "Server=.;Database=CellPhonesDb;Integrated Security=true;TrustServerCertificate=True");
});

// Add DI
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISlideRepository, SlideRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();


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

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
          name: "areasRoute",
          pattern: "{area:exists}/{controller=Admin}/{action=Index}"
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{slug?}"
        );

    // endpoints.MapControllerRoute(
    //     name: "Categories",
    //     pattern: "{controller=category}/{action=Index}/{slug?}"
    // );
});

app.Run();
