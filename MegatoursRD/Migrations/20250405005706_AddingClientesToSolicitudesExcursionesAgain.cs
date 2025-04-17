using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class AddingClientesToSolicitudesExcursionesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursiones_ClienteId",
                table: "SolicitudExcursiones",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursiones_Clientes_ClienteId",
                table: "SolicitudExcursiones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursiones_Clientes_ClienteId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudExcursiones_ClienteId",
                table: "SolicitudExcursiones");
        }
    }
}
