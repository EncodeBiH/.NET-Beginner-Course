using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.Configurations;

public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
{ 
    public const string TableName = "Projects";
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .ToTable(TableName);

        ConfigureRelationship(builder);
    }

    public static void ConfigureRelationship(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasMany(x => x.EmployeeProjects)
            .WithOne(x => x.Project)
            .HasForeignKey(x => x.ProjectId);
    }
}
