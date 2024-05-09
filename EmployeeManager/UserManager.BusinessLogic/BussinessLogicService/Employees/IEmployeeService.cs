using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.BussinessLogicService.Employees;

public interface IEmployeeService
{
    Employee? GetById(int id);

    void Create(string firstName, string lastName, int departmentId, DateOnly birthDate, string username, string password, string email);

    void Update(int id, string firstName, string lastName, int departmentId, DateOnly birtDate);

    void Delete(int id);
}
