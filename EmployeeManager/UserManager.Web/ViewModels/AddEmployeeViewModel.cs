using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManager.Web.ViewModels;

public class AddEmployeeViewModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public int DepartmentId { get; set; }

    public List<SelectListItem> Departments { get; set; }
}
