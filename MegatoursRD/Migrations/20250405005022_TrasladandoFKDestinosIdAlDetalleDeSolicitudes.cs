using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class TrasladandoFKDestinosIdAlDetalleDeSolicitudes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursiones_Clientes_ClienteId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursiones_Destinos_DestinoId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudExcursiones_ClienteId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudExcursiones_DestinoId",
                table: "SolicitudExcursiones");

            migrationBuilder.RenameColumn(
                name: "IdDestino",
                table: "SolicitudExcursionesDetalle",
                newName: "DestinoId");

            migrationBuilder.RenameColumn(
                name: "DestinoId",
                table: "SolicitudExcursiones",
                newName: "IdDestino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestinoId",
                table: "SolicitudExcursionesDetalle",
                newName: "IdDestino");

            migrationBuilder.RenameColumn(
                name: "IdDestino",
                table: "SolicitudExcursiones",
                newName: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursiones_ClienteId",
                table: "SolicitudExcursiones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursiones_DestinoId",
                table: "SolicitudExcursiones",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursiones_Clientes_ClienteId",
                table: "SolicitudExcursiones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursiones_Destinos_DestinoId",
                table: "SolicitudExcursiones",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "DestinoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
