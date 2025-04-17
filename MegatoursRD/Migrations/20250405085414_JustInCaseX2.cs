using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class JustInCaseX2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoOcupacionId",
                table: "Viajes");

            migrationBuilder.AddColumn<int>(
                name: "EstadoOcupacionId",
                table: "SolicitudExcursiones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoOcupacionId",
                table: "SolicitudExcursiones");

            migrationBuilder.AddColumn<int>(
                name: "EstadoOcupacionId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
