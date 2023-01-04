using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Zmianakluczy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccount_Accounts_ClientId",
                table: "ClientAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccount_Clients_AccountId",
                table: "ClientAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccount_Accounts_AccountId",
                table: "ClientAccount",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccount_Clients_ClientId",
                table: "ClientAccount",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccount_Accounts_AccountId",
                table: "ClientAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccount_Clients_ClientId",
                table: "ClientAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccount_Accounts_ClientId",
                table: "ClientAccount",
                column: "ClientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccount_Clients_AccountId",
                table: "ClientAccount",
                column: "AccountId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
