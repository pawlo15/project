using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class ClientAddressConfiguration : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.Property(p => p.AddressId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.ClientId)
                .IsRequired()
                .HasColumnType("int");

            builder.HasKey(p => new { p.AddressId, p.ClientId });

            builder.HasOne(p => p.Address)
                .WithOne(p => p.Client);

            builder.HasOne(p => p.Client)
                .WithOne(p => p.Address);
        }
    }
}
