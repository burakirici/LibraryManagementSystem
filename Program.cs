using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");

    options.LogoutPath = new PathString("/");

    options.AccessDeniedPath = new PathString("/");
});

var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();

app.MapDefaultControllerRoute();

app.Run();
