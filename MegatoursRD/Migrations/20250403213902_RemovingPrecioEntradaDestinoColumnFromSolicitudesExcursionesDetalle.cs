using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class RemovingPrecioEntradaDestinoColumnFromSolicitudesExcursionesDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioEntradaDestino",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.AddColumn<int>(
                name: "CantAdultos",
                table: "SolicitudExcursionesDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantNinos",
                table: "SolicitudExcursionesDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantAdultos",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropColumn(
                name: "CantNinos",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.AddColumn<double>(
                name: "PrecioEntradaDestino",
                table: "SolicitudExcursionesDetalle",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
