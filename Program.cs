using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using BibliothequeC_.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

var builder = WebApplication.CreateBuilder(args);

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login"; // login page
        options.LogoutPath = "/User/Logout"; // logout page
    });


builder.Services.AddDbContext<BookDb>(options =>
    options.UseSqlite("Data Source=book.db"));

builder.Services.AddDbContext<UserDb>(options =>
    options.UseSqlite("Data Source=user.db"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); 
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

var app = builder.Build();

app.MapControllers();

app.Run();