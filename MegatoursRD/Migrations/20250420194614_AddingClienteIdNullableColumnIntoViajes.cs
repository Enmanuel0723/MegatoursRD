using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class AddingClienteIdNullableColumnIntoViajes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Viajes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Viajes");
        }
    }
}
