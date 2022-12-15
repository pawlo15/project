using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Models.Client;

namespace Project.Infrastructure.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id)
                .IsClustered();

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(p => p.HasDebit)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(p => p.AccountNumber)
                .IsRequired()
                .HasColumnType("varchar(26)");

            builder.Property(p => p.Balance)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.DebitBalance)
                .IsRequired()
                .HasColumnType("decimal");
        }
    }
}
