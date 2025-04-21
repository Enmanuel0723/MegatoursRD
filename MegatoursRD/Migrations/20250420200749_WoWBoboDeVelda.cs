using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class WoWBoboDeVelda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantAdultos",
                table: "Viajes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CantNinos",
                table: "Viajes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEstipulada",
                table: "Viajes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantAdultos",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "CantNinos",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "FechaEstipulada",
                table: "Viajes");
        }
    }
}
