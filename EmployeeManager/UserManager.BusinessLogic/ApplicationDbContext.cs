using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic.Configurations;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<EmployeeProject> EmployeesProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        //modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

        //var employeeBuilder = modelBuilder.Entity<Employee>();

        //employeeBuilder
        //    .Property(x => x.FirstName)
        //    .HasMaxLength(255);

        //employeeBuilder
        //    .Property(x => x.LastName)
        //    .HasMaxLength(255);
    }
}
