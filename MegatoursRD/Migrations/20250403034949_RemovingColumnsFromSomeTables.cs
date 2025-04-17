using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class RemovingColumnsFromSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "SolicitudExcursiones");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "Cupos",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinoId",
                table: "SolicitudExcursiones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.DestinoId);
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "DestinoId", "Ciudad", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Punta Cana", "Famosa por sus playas de arena blanca y resorts de lujo. Ideal para actividades acuáticas como snorkel y buceo." },
                    { 2, "Samaná", "Conocida por sus impresionantes paisajes naturales, cascadas y avistamiento de ballenas. La Cascada El Limón es un atractivo popular." },
                    { 3, "Puerto Plata", "Hogar del teleférico de la Loma Isabel de Torres y hermosas playas como Playa Dorada. Ofrece una rica historia colonial." },
                    { 4, "La Romana", "Conocida por Altos de Chavón, una réplica de un pueblo mediterráneo, y las playas de Bayahibe, que son perfectas para el buceo." },
                    { 5, "Santo Domingo", "La capital del país, rica en historia y cultura. Visita la Zona Colonial, declarada Patrimonio de la Humanidad por la UNESCO." },
                    { 6, "Isla Saona", "Parte del Parque Nacional del Este, famosa por sus playas vírgenes y aguas turquesas. Ideal para excursiones en catamarán." },
                    { 7, "Jarabacoa", "Conocida como la 'ciudad de la eterna primavera', es perfecta para el ecoturismo, con actividades como rafting y senderismo." },
                    { 8, "Lago Enriquillo", "El lago más grande del Caribe, conocido por su biodiversidad y la posibilidad de ver cocodrilos y flamencos." },
                    { 9, "Parque Nacional Los Haitises", "Un área protegida con manglares, cuevas y una rica fauna. Ideal para excursiones en bote y exploración de la naturaleza." },
                    { 10, "Cabarete", "Famosa por sus deportes acuáticos, especialmente el kitesurf y el windsurf. También ofrece una vibrante vida nocturna." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursiones_DestinoId",
                table: "SolicitudExcursiones",
                column: "DestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudExcursiones_Destinos_DestinoId",
                table: "SolicitudExcursiones",
                column: "DestinoId",
                principalTable: "Destinos",
                principalColumn: "DestinoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudExcursiones_Destinos_DestinoId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudExcursiones_DestinoId",
                table: "SolicitudExcursiones");

            migrationBuilder.DropColumn(
                name: "Cupos",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "DestinoId",
                table: "SolicitudExcursiones");

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "SolicitudExcursiones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
