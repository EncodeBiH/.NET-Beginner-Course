using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.Configurations;

public class EmployeeProjectEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder
            .HasKey(x => x.Id);
    }
}
