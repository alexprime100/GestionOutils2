using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Manuels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Manuels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomOutil",
                table: "Manuels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Prix",
                table: "Manuels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Manuels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateNaissance",
                value: new DateTime(2022, 3, 29, 20, 7, 52, 527, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateNaissance",
                value: new DateTime(2022, 3, 29, 20, 7, 52, 536, DateTimeKind.Local).AddTicks(9000));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Manuels");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Manuels");

            migrationBuilder.DropColumn(
                name: "NomOutil",
                table: "Manuels");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Manuels");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Manuels");

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateNaissance",
                value: new DateTime(2022, 3, 6, 13, 42, 56, 424, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateNaissance",
                value: new DateTime(2022, 3, 6, 13, 42, 56, 429, DateTimeKind.Local).AddTicks(5206));
        }
    }
}
