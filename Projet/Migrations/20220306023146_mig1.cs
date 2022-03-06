using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserAdress", "UserDateOfBirth", "UserEmail", "UserFirstName", "UserName", "UserPassword", "UserRole" },
                values: new object[] { 1L, "adress1", new DateTime(2022, 3, 5, 21, 31, 46, 613, DateTimeKind.Local).AddTicks(4610), "user@mail.com", "user", "user", "eUNII0SSTvlI7K6LMD/F5aMGGEm3Fj1d89N4HOoFKAE=", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserAdress", "UserDateOfBirth", "UserEmail", "UserFirstName", "UserName", "UserPassword", "UserRole" },
                values: new object[] { 2L, "adress2", new DateTime(2022, 3, 5, 21, 31, 46, 618, DateTimeKind.Local).AddTicks(3022), "admin@mail.com", "admin", "admin", "OHVv+u4mWEQqeCR0MfD8jlPCST6M8f0AYab+lDy+TRI=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
