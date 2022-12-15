using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.User;

namespace Project.Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(p => p.RoleId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.UserId)
                .IsRequired()
                .HasColumnType("int");

            builder.HasKey(p => new { p.UserId, p.RoleId });

            builder.HasOne(p => p.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.RoleId);

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.UserId);
        }
    }
}
