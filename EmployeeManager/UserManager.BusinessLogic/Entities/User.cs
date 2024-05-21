using Microsoft.AspNetCore.Identity;

namespace UserManager.BusinessLogic.Entities;

public class User : IdentityUser<int>
{
    public Employee Employee { get; set; }
}
