using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic;
using UserManager.BusinessLogic.BussinessLogicService.Employees;
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
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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
    pattern: "{controller=Employee}/{action=Index}/{id?}"
);

app.Run();
