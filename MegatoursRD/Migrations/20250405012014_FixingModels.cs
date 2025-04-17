using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class FixingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "FechaViaje",
                table: "Viajes");

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "Viajes",
                newName: "ListaDestinos");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "SolicitudExcursiones",
                newName: "FechaCreacion");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 4,
                column: "Descripcion",
                value: "Abierto");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 5,
                column: "Descripcion",
                value: "Finalizado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListaDestinos",
                table: "Viajes",
                newName: "Nota");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "SolicitudExcursiones",
                newName: "Fecha");

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Viajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaViaje",
                table: "Viajes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 4,
                column: "Descripcion",
                value: "Atrasado");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 5,
                column: "Descripcion",
                value: "En tiempo");
        }
    }
}
