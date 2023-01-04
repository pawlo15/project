using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class ClientAccountConfiguration : IEntityTypeConfiguration<ClientAccount>
    {
        public void Configure(EntityTypeBuilder<ClientAccount> builder)
        {
            builder.HasKey(ca => new { ca.AccountId, ca.ClientId });

            builder.Property(p => p.AccountId)
                .HasColumnType("int");

            builder.Property(p => p.ClientId)
                .HasColumnType("int");

            builder.HasOne(ca => ca.Client)
                .WithMany(c => c.Accounts)
                .HasForeignKey(ca => ca.ClientId);

            builder.HasOne(ca => ca.Account)
                .WithMany(a => a.Clients)
                .HasForeignKey(ca => ca.AccountId);
                
        }
    }
}
