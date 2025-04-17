using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class AddingGuiasAndEstadosPagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "SolicitudExcursiones",
                newName: "FechaEstipulada");

            migrationBuilder.AddColumn<int>(
                name: "EstadoPagoId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuiaId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadosDePago",
                columns: table => new
                {
                    EstadoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDePago", x => x.EstadoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    GuiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.GuiaId);
                });

            migrationBuilder.InsertData(
                table: "EstadosDePago",
                columns: new[] { "EstadoPagoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pagado" },
                    { 2, "No pagado" },
                    { 3, "Vencido" }
                });

            migrationBuilder.InsertData(
                table: "Guias",
                columns: new[] { "GuiaId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Jorge Ceballos" },
                    { 2, "Alexandra Terrero" },
                    { 3, "Saúl Cremades" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosDePago");

            migrationBuilder.DropTable(
                name: "Guias");

            migrationBuilder.DropColumn(
                name: "EstadoPagoId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "GuiaId",
                table: "Viajes");

            migrationBuilder.RenameColumn(
                name: "FechaEstipulada",
                table: "SolicitudExcursiones",
                newName: "FechaCreacion");
        }
    }
}
