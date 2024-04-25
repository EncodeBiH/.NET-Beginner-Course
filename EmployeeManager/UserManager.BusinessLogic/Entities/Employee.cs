namespace UserManager.BusinessLogic.Entities;

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public DateOnly BirthDate { get; set; }

    public User User { get; set; }

    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
}
