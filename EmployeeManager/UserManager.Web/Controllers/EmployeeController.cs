using Microsoft.AspNetCore.Mvc;
using UserManager.BusinessLogic;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Controllers;

public class EmployeeController : Controller
{
    public EmployeeController()
    {
        
    }

    public IActionResult Index()
    {
        var response = new EmployeeIndexViewModel
        {
            Employees = EmployeeStore.Store
        };

        return View(response);
    }
}
