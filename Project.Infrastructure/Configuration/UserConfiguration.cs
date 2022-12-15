using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.User;

namespace Project.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id)
                .IsClustered();

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Login)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.PasswordSalt)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .IsRequired();

        }
    }
}
