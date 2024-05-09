using Microsoft.AspNetCore.Mvc.Rendering;
using UserManager.BusinessLogic.Entities;

namespace UserManager.Web.ViewModels;

public class AddEmployeeViewModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public int DepartmentId { get; set; }
}
