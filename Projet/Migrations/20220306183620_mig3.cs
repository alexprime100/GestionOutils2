using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Users",
                newName: "Telephone");

            migrationBuilder.RenameColumn(
                name: "UserPhoneNumber",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "Users",
                newName: "MotDePasse");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Courriel");

            migrationBuilder.RenameColumn(
                name: "UserDateOfBirth",
                table: "Users",
                newName: "DateNaissance");

            migrationBuilder.RenameColumn(
                name: "UserAdress",
                table: "Users",
                newName: "Adresse");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateNaissance", "MotDePasse", "Prenom", "Role", "Telephone" },
                values: new object[] { new DateTime(2022, 3, 6, 13, 36, 20, 419, DateTimeKind.Local).AddTicks(8760), "eUNII0SSTvlI7K6LMD/F5aMGGEm3Fj1d89N4HOoFKAE=", "user", "User", "111" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateNaissance", "MotDePasse", "Prenom", "Role", "Telephone" },
                values: new object[] { new DateTime(2022, 3, 6, 13, 36, 20, 424, DateTimeKind.Local).AddTicks(6875), "OHVv+u4mWEQqeCR0MfD8jlPCST6M8f0AYab+lDy+TRI=", "admin", "Admin", "222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Users",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "MotDePasse",
                table: "Users",
                newName: "UserFirstName");

            migrationBuilder.RenameColumn(
                name: "DateNaissance",
                table: "Users",
                newName: "UserDateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Courriel",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "Users",
                newName: "UserAdress");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "UserDateOfBirth", "UserFirstName", "UserPassword", "UserPhoneNumber", "UserRole" },
                values: new object[] { new DateTime(2022, 3, 6, 12, 14, 47, 0, DateTimeKind.Local).AddTicks(2717), "user", "eUNII0SSTvlI7K6LMD/F5aMGGEm3Fj1d89N4HOoFKAE=", null, "User" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L,
                columns: new[] { "UserDateOfBirth", "UserFirstName", "UserPassword", "UserPhoneNumber", "UserRole" },
                values: new object[] { new DateTime(2022, 3, 6, 12, 14, 47, 5, DateTimeKind.Local).AddTicks(2279), "admin", "OHVv+u4mWEQqeCR0MfD8jlPCST6M8f0AYab+lDy+TRI=", null, "Admin" });
        }
    }
}
