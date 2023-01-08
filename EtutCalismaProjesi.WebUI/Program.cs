using EtutCalismaProjesi.Data.Absract;
using EtutCalismaProjesi.Data.Concreate;
using EtutCalismaProjesi.Data;
using EtutCalismaProjesi.Service.Absract;
using EtutCalismaProjesi.Service.Concreate;

using Microsoft.AspNetCore.Authentication.Cookies;
using NToastNotify;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000

    });

builder.Services.AddDbContext<DatabaseContext>(); 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    //x.LoginPath = "/Admin/Login"; 
    //x.Cookie.Name = "AdminLogin";
    x.LoginPath = "/Admin/Login";
    x.LogoutPath = "/Admin/Login/Logout";
    x.Cookie.Name = "AdminLogin";
    x.AccessDeniedPath = "/AccessDenied";
    x.Cookie.MaxAge = TimeSpan.FromDays(1000);
});




builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));


// yetkilendirme Ayarları 
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "User"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
      );


app.Run();