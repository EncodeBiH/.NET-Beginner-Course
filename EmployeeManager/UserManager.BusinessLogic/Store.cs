using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic;

public static class Store
{
    public static int EmployeeIdGenerator = 3;

    public static List<Department> Departments = 
    [
        new Department
        {
            Id = 1,
            Name = "Engineering",
            Code = "ENG"
        },
        new Department
        {
            Id = 2,
            Name = "Software quality testing",
            Code = "QA"
        }
    ];

    public static List<Employee> Employees =
    [
        new Employee()
        {
            Id = 1,
            FirstName = "Emir",
            LastName = "Veledar",
            BirthDate = new DateOnly(1997, 12, 23),
            DepartmentId = 1
        },
        new Employee()
        {
            Id = 2,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1986, 4, 6),
            DepartmentId = 2
        },
        new Employee()
        {
            Id = 3,
            FirstName = "Jane",
            LastName = "Doe",
            BirthDate = new DateOnly(1977, 3, 8),
            DepartmentId = 1
        }
    ];
}
