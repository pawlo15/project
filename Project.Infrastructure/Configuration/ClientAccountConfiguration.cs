using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class ClientAccountConfiguration : IEntityTypeConfiguration<ClientAccount>
    {
        public void Configure(EntityTypeBuilder<ClientAccount> builder)
        {
            builder.Property(p => p.AccountId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.ClientId)
                .IsRequired()
                .HasColumnType("int");

            builder.HasKey(p => new { p.AccountId, p.ClientId });

            builder.HasOne(p => p.Account)
                .WithMany(p => p.Clients)
                .HasForeignKey(p => p.ClientId);

            builder.HasOne(p => p.Client)
                .WithMany(p => p.Accounts)
                .HasForeignKey(p => p.AccountId);
                

        }
    }
}
