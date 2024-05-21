using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.BussinessLogicService.UserService;

public interface IUserService
{
    User GetByEmail(string email);
}
