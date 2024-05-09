using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.BusinessLogic.Entities;

namespace UserManager.BusinessLogic.Configurations;

public  class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.Email)
            .HasMaxLength(255);

        builder
            .Property(x => x.Username)
            .HasMaxLength(15);

        ConfigureRelationship(builder);
    }

    public static void ConfigureRelationship(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(x => x.Employee)
            .WithOne(x => x.User)
            .HasForeignKey<Employee>(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
