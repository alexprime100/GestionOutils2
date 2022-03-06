using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "UserDateOfBirth",
                value: new DateTime(2022, 3, 6, 12, 14, 47, 0, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "UserDateOfBirth",
                value: new DateTime(2022, 3, 6, 12, 14, 47, 5, DateTimeKind.Local).AddTicks(2279));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "UserDateOfBirth",
                value: new DateTime(2022, 3, 5, 21, 31, 46, 613, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                column: "UserDateOfBirth",
                value: new DateTime(2022, 3, 5, 21, 31, 46, 618, DateTimeKind.Local).AddTicks(3022));
        }
    }
}
