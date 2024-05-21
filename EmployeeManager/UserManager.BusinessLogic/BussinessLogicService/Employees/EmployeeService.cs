using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.BussinessLogicService.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly UserManager<User> _userManager;

    public EmployeeService
    (
        ApplicationDbContext applicationDbContext,
        UserManager<User> userManager
    )
    {
        _applicationDbContext = applicationDbContext;
        _userManager = userManager;
    }

    public Employee? GetById(int id)
    {
        return _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
    }

    public async Task Create(string firstName, string lastName, int departmentId, DateOnly birthDate, string username, string password, string email)
    {
        var user = new User
        {
            UserName = username,
            Email = email
        };

        var identityResult = await _userManager.CreateAsync(user, password);

        if (identityResult.Succeeded)
        {
            _applicationDbContext.Add(new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = departmentId,
                BirthDate = birthDate,
                User = user
            });

            await _applicationDbContext.SaveChangesAsync();
        }
    }

    public void Update(int id, string firstName, string lastName, int departmentId, DateOnly birtDate)
    {
        var employee = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);

        if (employee is null)
        {
            return;
        }

        employee.FirstName = firstName;
        employee.LastName = lastName;
        employee.DepartmentId = departmentId;
        employee.BirthDate = birtDate;

        _applicationDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = _applicationDbContext
            .Employees
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        if (employee is null)
        {
            return;
        }
        _applicationDbContext.Employees.Remove(employee);
        _applicationDbContext.Users.Remove(employee.User);

        _applicationDbContext.SaveChanges();
    }
}
