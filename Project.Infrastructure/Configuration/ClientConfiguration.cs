using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(p => p.Id)
                .IsClustered();

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Pesel)
                .HasColumnType("varchar(12)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.PhoneNumber)
                .HasColumnType("varchar(15)");

            builder.HasOne(p => p.Address)
                .WithOne(p => p.Client);
        }
    }
}
