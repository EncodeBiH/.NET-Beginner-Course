using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<EmployeeProject> EmployeesProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        //modelBuilder
        //    .Entity<Department>()
        //    .Metadata
        //    .GetForeignKeys()
        //    .ToList()
        //    .ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
    }
}
