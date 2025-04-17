using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class AddingDestinosToSolicitudExcursionesDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursionesDetalle_DestinoId",
                table: "SolicitudExcursionesDetalle",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursionesDetalle_Destinos_DestinoId",
                table: "SolicitudExcursionesDetalle",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "DestinoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursionesDetalle_Destinos_DestinoId",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudExcursionesDetalle_DestinoId",
                table: "SolicitudExcursionesDetalle");
        }
    }
}
