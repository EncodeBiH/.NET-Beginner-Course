namespace UserManager.BusinessLogic.Entities;

public class Employee
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Department { get; set; }

    public DateOnly BirthDate { get; set; }
}
