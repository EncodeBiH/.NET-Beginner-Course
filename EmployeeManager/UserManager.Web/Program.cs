using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic;
using UserManager.BusinessLogic.BussinessLogicService.Employees;
using UserManager.BusinessLogic.BussinessLogicService.UserService;
using UserManager.BusinessLogic.Entities;
using UserManager.Web.Services;
using UserManager.Web.Validators;
using UserManager.Web.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder
    .Services
    .AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });

builder
    .Services
    .AddScoped<ISelectListService, SelectListService>();

builder
    .Services
    .AddScoped<IEmployeeService, EmployeeService>();

builder
    .Services
    .AddScoped<IUserService, UserService>();

builder
    .Services
    .AddAuthorization();

builder
    .Services
    .AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder
//    .Services.Configure<IdentityOptions>(options =>
//    {
//    });

builder
    .Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder
    .Services
    .Configure<AuthenticationOptions>(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

builder
    .Services
    .Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

    options.AccessDeniedPath = new PathString("/login/login");
    options.LoginPath = new PathString("/login/login");
    options.LogoutPath = new PathString("/logout/logout");
});

// AddScoped or AddTransient or AddSingleton

builder
    .Services
    .AddScoped<IValidator<AddEmployeeViewModel>, AddEmployeeViewModelValidator>();

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute
(
    name: "default",
    pattern: "{controller=login}/{action=login}/{id?}"
);

app.Run();
