using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class AlmostReadyBro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursionesDetalle_SolicitudExcursiones_SolicitudExcursionId",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_SolicitudExcursiones_SolicitudExcursionId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_SolicitudExcursionId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "ListaDestinos",
                table: "Viajes");

            migrationBuilder.RenameColumn(
                name: "SolicitudExcursionId",
                table: "SolicitudExcursionesDetalle",
                newName: "SolicitudViajeId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudExcursionesDetalle_SolicitudExcursionId",
                table: "SolicitudExcursionesDetalle",
                newName: "IX_SolicitudExcursionesDetalle_SolicitudViajeId");

            migrationBuilder.RenameColumn(
                name: "SolicitudExcursionId",
                table: "SolicitudExcursiones",
                newName: "SolicitudViajeId");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitudExcursionId",
                table: "Viajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GuiaId",
                table: "Viajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SolicitudViajeId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoVencimientoId",
                table: "SolicitudExcursiones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PrecioGuia",
                table: "Guias",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "EstadosVencimiento",
                columns: table => new
                {
                    EstadoVencimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosVencimiento", x => x.EstadoVencimientoId);
                });

            migrationBuilder.InsertData(
                table: "EstadosVencimiento",
                columns: new[] { "EstadoVencimientoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Vigente" },
                    { 2, "Vencida" }
                });

            migrationBuilder.UpdateData(
                table: "Guias",
                keyColumn: "GuiaId",
                keyValue: 1,
                column: "PrecioGuia",
                value: 5500.0);

            migrationBuilder.UpdateData(
                table: "Guias",
                keyColumn: "GuiaId",
                keyValue: 2,
                column: "PrecioGuia",
                value: 5500.0);

            migrationBuilder.UpdateData(
                table: "Guias",
                keyColumn: "GuiaId",
                keyValue: 3,
                column: "PrecioGuia",
                value: 5500.0);

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_GuiaId",
                table: "Viajes",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_SolicitudViajeId",
                table: "Viajes",
                column: "SolicitudViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursionesDetalle_SolicitudExcursiones_SolicitudViajeId",
                table: "SolicitudExcursionesDetalle",
                column: "SolicitudViajeId",
                principalTable: "SolicitudExcursiones",
                principalColumn: "SolicitudViajeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Guias_GuiaId",
                table: "Viajes",
                column: "GuiaId",
                principalTable: "Guias",
                principalColumn: "GuiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_SolicitudExcursiones_SolicitudViajeId",
                table: "Viajes",
                column: "SolicitudViajeId",
                principalTable: "SolicitudExcursiones",
                principalColumn: "SolicitudViajeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursionesDetalle_SolicitudExcursiones_SolicitudViajeId",
                table: "SolicitudExcursionesDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Guias_GuiaId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_SolicitudExcursiones_SolicitudViajeId",
                table: "Viajes");

            migrationBuilder.DropTable(
                name: "EstadosVencimiento");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_GuiaId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_SolicitudViajeId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "SolicitudViajeId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "EstadoVencimientoId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropColumn(
                name: "PrecioGuia",
                table: "Guias");

            migrationBuilder.RenameColumn(
                name: "SolicitudViajeId",
                table: "SolicitudExcursionesDetalle",
                newName: "SolicitudExcursionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudExcursionesDetalle_SolicitudViajeId",
                table: "SolicitudExcursionesDetalle",
                newName: "IX_SolicitudExcursionesDetalle_SolicitudExcursionId");

            migrationBuilder.RenameColumn(
                name: "SolicitudViajeId",
                table: "SolicitudExcursiones",
                newName: "SolicitudExcursionId");

            migrationBuilder.AlterColumn<int>(
                name: "SolicitudExcursionId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuiaId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListaDestinos",
                table: "Viajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_SolicitudExcursionId",
                table: "Viajes",
                column: "SolicitudExcursionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursionesDetalle_SolicitudExcursiones_SolicitudExcursionId",
                table: "SolicitudExcursionesDetalle",
                column: "SolicitudExcursionId",
                principalTable: "SolicitudExcursiones",
                principalColumn: "SolicitudExcursionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_SolicitudExcursiones_SolicitudExcursionId",
                table: "Viajes",
                column: "SolicitudExcursionId",
                principalTable: "SolicitudExcursiones",
                principalColumn: "SolicitudExcursionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
