namespace UserManager.Web.ViewModels;

public class EmployeeIndexViewModel
{
    public int TotalNumberOfEmployees { get; set; }

    public List<EmployeeViewModel> Employees { get; set; }
}

public class EmployeeViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Department { get; set; }
}