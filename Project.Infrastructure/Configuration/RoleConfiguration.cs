using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.User;

namespace Project.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasKey(p => p.Id)
                .IsClustered();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
