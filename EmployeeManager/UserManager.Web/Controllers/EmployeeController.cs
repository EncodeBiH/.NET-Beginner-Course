using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic;
using UserManager.BusinessLogic.Entities;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Controllers;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IValidator<AddEmployeeViewModel> _addEmployeeValidator;

    public EmployeeController
    (
        ApplicationDbContext context,
        IValidator<AddEmployeeViewModel> addEmployeeValidator
    )
    {
        _context = context;
        _addEmployeeValidator = addEmployeeValidator;
    }

    public IActionResult Index()
    {
        var numberOfEmployees = _context.Employees.Count();

        var employees = _context
            .Employees
            .AsNoTracking()
            .Include(x => x.Department)
            .Select(employee => new EmployeeViewModel
            {
                Id = employee.Id,
                FullName = $"{employee.FirstName} {employee.LastName}",
                Department = employee.Department.Name
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
        return View(new AddEmployeeViewModel());
    }

    [HttpPost]
    public IActionResult Add([FromForm] AddEmployeeViewModel request)
    {
        var validationResult = _addEmployeeValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);

            return View(request);
        }

        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DepartmentId = request.DepartmentId,
            BirthDate = request.BirthDate,
            User = new User()
            {
                Email = "demo@demo.com",
                Password = "test",
                Username = "test"
            }
        };

        _context.Employees.Add(employee);

        _context.SaveChanges();

        TempData["Success"] = "You have successfully added employee.";

        return RedirectToAction("Index");
    }

    public IActionResult Edit([FromRoute] int id)
    {
        var employee = _context
            .Employees
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (employee is null)
        {
            NotFound();
        }

        var editEmployeeViewModel = new EditEmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DepartmentId = employee.DepartmentId,
            BirthDate = employee.BirthDate
        };

        return View(editEmployeeViewModel);
    }

    [HttpPost]
    public IActionResult Edit([FromRoute] int id, [FromForm] EditEmployeeViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var employee = _context
            .Employees
            .FirstOrDefault(x => x.Id == id);

        if (employee is null)
        {
            return NotFound();
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DepartmentId = request.DepartmentId;
        employee.BirthDate = request.BirthDate;

        //_context.Employees.Update(employee);

        _context.SaveChanges();

        TempData["Success"] = "You have successfully edited employee.";

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete([FromRoute] int id)
    {
        var employee = _context
            .Employees
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        if (employee is null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        _context.Users.Remove(employee.User);

        _context.SaveChanges();

        TempData["Success"] = "You have successfully deleted employee.";

        return RedirectToAction("Index");
    }
}
    