using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WowFoodsApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeStaffSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Users_EmployeeId",
                table: "EmployeeStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff");

            migrationBuilder.RenameTable(
                name: "EmployeeStaff",
                newName: "EmployeeStaffs");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeStaffs",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeeStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStaffs",
                table: "EmployeeStaffs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "EmployeeStaffs",
                columns: new[] { "Id", "DateOfJoining", "IsActive", "Salary", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6000.0, 1 },
                    { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8000.0, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaffs_Users_Id",
                table: "EmployeeStaffs",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaffs_Users_Id",
                table: "EmployeeStaffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStaffs",
                table: "EmployeeStaffs");

            migrationBuilder.DeleteData(
                table: "EmployeeStaffs",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeStaffs",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeStaffs");

            migrationBuilder.RenameTable(
                name: "EmployeeStaffs",
                newName: "EmployeeStaff");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EmployeeStaff",
                newName: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaff_Users_EmployeeId",
                table: "EmployeeStaff",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
