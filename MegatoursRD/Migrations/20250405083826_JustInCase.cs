using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class JustInCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolicitudExcursionId",
                table: "Viajes");

            migrationBuilder.AddColumn<int>(
                name: "EstadoOcupacionId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadosOcupacion",
                columns: table => new
                {
                    EstadoOcupacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosOcupacion", x => x.EstadoOcupacionId);
                });

            migrationBuilder.InsertData(
                table: "EstadosOcupacion",
                columns: new[] { "EstadoOcupacionId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Ocupado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosOcupacion");

            migrationBuilder.DropColumn(
                name: "EstadoOcupacionId",
                table: "Viajes");

            migrationBuilder.AddColumn<int>(
                name: "SolicitudExcursionId",
                table: "Viajes",
                type: "int",
                nullable: true);
        }
    }
}
