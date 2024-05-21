using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.BussinessLogicService.UserService;
public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(x => x.Email == email);
    }
}
