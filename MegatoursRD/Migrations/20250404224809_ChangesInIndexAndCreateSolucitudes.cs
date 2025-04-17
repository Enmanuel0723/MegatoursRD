using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInIndexAndCreateSolucitudes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreSolicitante",
                table: "SolicitudExcursiones",
                newName: "Asunto");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "SolicitudExcursionesDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "SolicitudExcursionesDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdDestino",
                table: "SolicitudExcursionesDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropColumn(
                name: "IdDestino",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.RenameColumn(
                name: "Asunto",
                table: "SolicitudExcursiones",
                newName: "NombreSolicitante");
        }
    }
}
