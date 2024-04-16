using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManager.BusinessLogic;
using UserManager.BusinessLogic.Entities;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Controllers;

public class EmployeeController : Controller
{
    public EmployeeController()
    {
        
    }

    public IActionResult Index()
    {
        var numberOfEmployees = Store.Employees.Count;

        var employees = Store
            .Employees
            .Select(employee => new EmployeeViewModel
            {
                Id = employee.Id,
                FullName = $"{employee.FirstName} {employee.LastName}",
                Department = Store.Departments.First(x => x.Id == employee.DepartmentId).Name
            })
            .ToList();

        var response = new EmployeeIndexViewModel
        {
            TotalNumberOfEmployees = numberOfEmployees,
            Employees = employees,
        };

        return View(response);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var addViewModel = new AddEmployeeViewModel();

        FillEmployeeViewModel(addViewModel);

        return View(addViewModel);
    }

    [HttpPost]
    public IActionResult Add([FromForm] AddEmployeeViewModel request)
    {
        if (!ValidateEmployee(request))
        {
            TempData["Error"] = "Fix the validation errors.";

            FillEmployeeViewModel(request);

            return View(request);
        }
        var employee = new Employee
        {
            Id = ++Store.EmployeeIdGenerator,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DepartmentId = request.DepartmentId,
            BirthDate = request.BirthDate
        };

        Store.Employees.Add(employee);

        TempData["Success"] = "You have successfully added employee.";

        return RedirectToAction("Index");
    }

    public IActionResult Edit([FromRoute] int id)
    {
        var employee = Store.Employees.First(x => x.Id == id);

        var editEmployeeViewModel = new EditEmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DepartmentId = employee.DepartmentId,
            BirthDate = employee.BirthDate
        };

        FillEditEmployeeViewModel(editEmployeeViewModel);

        return View(editEmployeeViewModel);
    }

    [HttpPost]
    public IActionResult Edit([FromRoute] int id, [FromForm] EditEmployeeViewModel request)
    {
        var employee = Store.Employees.First(x => x.Id == id);

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DepartmentId = request.DepartmentId;
        employee.BirthDate = request.BirthDate;

        TempData["Success"] = "You have successfully edited employee.";

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete([FromRoute] int id)
    {
        var employee = Store.Employees.First(x => x.Id == id);

        Store.Employees.Remove(employee);

        TempData["Success"] = "You have successfully deleted employee.";

        return RedirectToAction("Index");
    }

    private bool ValidateEmployee(AddEmployeeViewModel request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return false;
        }

        return true;
    }

    private void FillEmployeeViewModel(AddEmployeeViewModel request)
    {
        var departments = Store
            .Departments
            .Select(department => new SelectListItem
            {
                Text = department.Name,
                Value = department.Id.ToString()
            })
            .ToList();

        request.Departments = departments;
    }

    private void FillEditEmployeeViewModel(EditEmployeeViewModel request)
    {
        var departments = Store
            .Departments
            .Select(department => new SelectListItem
            {
                Text = department.Name,
                Value = department.Id.ToString()
            })
            .ToList();

        request.Departments = departments;
    }
}
    