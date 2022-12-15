﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infrastructure.Data;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(26)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal");

                    b.Property<decimal>("DebitBalance")
                        .HasColumnType("decimal");

                    b.Property<short>("HasDebit")
                        .HasColumnType("smallint");

                    b.Property<short>("IsActive")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.ClientAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAccount");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.ClientAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("AddressId", "ClientId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("ClientAddress");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.ClientAccount", b =>
                {
                    b.HasOne("Project.Infrastructure.Models.Client.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Models.Client.Account", "Account")
                        .WithMany("Clients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.ClientAddress", b =>
                {
                    b.HasOne("Project.Infrastructure.Models.Client.Address", "Address")
                        .WithOne("Client")
                        .HasForeignKey("Project.Infrastructure.Models.Client.ClientAddress", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Models.Client.Client", "Client")
                        .WithOne("Address")
                        .HasForeignKey("Project.Infrastructure.Models.Client.ClientAddress", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.UserRole", b =>
                {
                    b.HasOne("Project.Infrastructure.Models.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Models.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Account", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Address", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Infrastructure.Models.Client.Client", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Project.Infrastructure.Models.User.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}