namespace UserManager.Web.ViewModels;

public class EditEmployeeViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public int DepartmentId { get; set; }
}
