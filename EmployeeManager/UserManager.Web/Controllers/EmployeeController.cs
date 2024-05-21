using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic;
using UserManager.BusinessLogic.BussinessLogicService.Employees;
using UserManager.Web.ViewModels;

namespace UserManager.Web.Controllers;

[Authorize]
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IEmployeeService _employeeService;
    private readonly IValidator<AddEmployeeViewModel> _addEmployeeValidator;

    public EmployeeController
    (
        ApplicationDbContext context,
        IEmployeeService employeeService,
        IValidator<AddEmployeeViewModel> addEmployeeValidator
    )
    {
        _context = context;
        _employeeService = employeeService;
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
    public async Task<IActionResult> Add([FromForm] AddEmployeeViewModel request)
    {
        var validationResult = _addEmployeeValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);

            return View(request);
        }

        await _employeeService.Create(request.FirstName, request.LastName, request.DepartmentId, request.BirthDate, request.Username, request.Password, request.Email);

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

        _employeeService.Update(id, request.FirstName, request.LastName, request.DepartmentId, request.BirthDate);

        TempData["Success"] = "You have successfully edited employee.";

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete([FromRoute] int id)
    {
        _employeeService.Delete(id);

        TempData["Success"] = "You have successfully deleted employee.";

        return RedirectToAction("Index");
    }
}
    