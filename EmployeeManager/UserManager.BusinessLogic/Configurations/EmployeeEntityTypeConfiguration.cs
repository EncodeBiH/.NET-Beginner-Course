using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.Configurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    private const string TableName = "Employees";

    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable(TableName);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(255);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(255);

        ConfigureRelationships(builder);
    }

    public static void ConfigureRelationships(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId);

        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.Id);

        builder
            .HasMany(x => x.EmployeeProjects)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);
    }
}
