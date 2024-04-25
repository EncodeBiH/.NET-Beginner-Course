using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.Configurations;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    private const string TableName = "Departments";

    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable(TableName);

        builder
            .Property(x => x.Code)
            .HasMaxLength(3)
            .IsFixedLength();
    }
}