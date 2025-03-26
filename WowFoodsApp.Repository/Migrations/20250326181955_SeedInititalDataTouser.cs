using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WowFoodsApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedInititalDataTouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, "123", "Admin", "admin" },
                    { 2, "123", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "User", "1234567890", 1 },
                    { 2, "user@example.com", "Regular", "User", "0987654321", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
