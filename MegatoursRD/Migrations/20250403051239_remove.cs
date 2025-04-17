using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 1,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 2,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 3,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 4,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 5,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 6,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 8,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 9,
                column: "Cupos",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 10,
                column: "Cupos",
                value: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 1,
                column: "Cupos",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 2,
                column: "Cupos",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 3,
                column: "Cupos",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 4,
                column: "Cupos",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 5,
                column: "Cupos",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 6,
                column: "Cupos",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 8,
                column: "Cupos",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 9,
                column: "Cupos",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Destinos",
                keyColumn: "DestinoId",
                keyValue: 10,
                column: "Cupos",
                value: 26);
        }
    }
}
