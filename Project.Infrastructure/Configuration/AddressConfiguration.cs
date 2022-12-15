using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id)
               .IsClustered();

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ApartmentNumber)
                .HasColumnType("varchar(6)");

            builder.Property(p => p.HouseNumber)
                .IsRequired()
                .HasColumnType("varchar(6)");

            builder.Property(p => p.Street)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.PostalCode)
                .IsRequired()
                .HasColumnType("varchar(7)");

        }
    }
}
