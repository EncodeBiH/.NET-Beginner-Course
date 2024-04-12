using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic;

public static class EmployeeStore
{
    public static List<Employee> Store =
    [
        new Employee()
        {
            FirstName = "Emir",
            LastName = "Veledar",
            BirthDate = new DateOnly(1997, 12, 23),
            Department = "Engineering"
        }
    ];
}
