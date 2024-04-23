using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }
}
