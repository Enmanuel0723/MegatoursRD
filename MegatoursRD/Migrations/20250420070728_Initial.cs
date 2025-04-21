using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegatoursRD.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    FechaEstipulada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioEntrada = table.Column<double>(type: "float", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.DestinoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

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

            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    GuiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioGuia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.GuiaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_AspNetUsers_AplicationUserId",
                        column: x => x.AplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SesionAnonimaId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "SolicitudExcursiones",
                columns: table => new
                {
                    SolicitudViajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    EstadoVencimientoId = table.Column<int>(type: "int", nullable: false),
                    EstadoOcupacionId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    IdDestino = table.Column<int>(type: "int", nullable: false),
                    FechaEstipulada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantAdultos = table.Column<int>(type: "int", nullable: false),
                    CantNinos = table.Column<int>(type: "int", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudExcursiones", x => x.SolicitudViajeId);
                    table.ForeignKey(
                        name: "FK_SolicitudExcursiones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoDetalles",
                columns: table => new
                {
                    CarritoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    CantAdultos = table.Column<int>(type: "int", nullable: false),
                    CantNinos = table.Column<int>(type: "int", nullable: false),
                    PrecioAdultos = table.Column<double>(type: "float", nullable: false),
                    PrecioNinos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoDetalles", x => x.CarritoDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoDetalles_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoDetalles_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudExcursionesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudViajeId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantAdultos = table.Column<int>(type: "int", nullable: false),
                    CantNinos = table.Column<int>(type: "int", nullable: false),
                    PrecioAdultos = table.Column<double>(type: "float", nullable: false),
                    PrecioNinos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudExcursionesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_SolicitudExcursionesDetalle_Destinos_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destinos",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudExcursionesDetalle_SolicitudExcursiones_SolicitudViajeId",
                        column: x => x.SolicitudViajeId,
                        principalTable: "SolicitudExcursiones",
                        principalColumn: "SolicitudViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    EstadoPagoId = table.Column<int>(type: "int", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: true),
                    SolicitudViajeId = table.Column<int>(type: "int", nullable: false),
                    PrecioFinal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.ViajeId);
                    table.ForeignKey(
                        name: "FK_Viajes_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "GuiaId");
                    table.ForeignKey(
                        name: "FK_Viajes_SolicitudExcursiones_SolicitudViajeId",
                        column: x => x.SolicitudViajeId,
                        principalTable: "SolicitudExcursiones",
                        principalColumn: "SolicitudViajeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "DestinoId", "Ciudad", "Cupos", "Descripcion", "FechaEstipulada", "ImagenUrl", "PrecioEntrada" },
                values: new object[,]
                {
                    { 1, "Punta Cana", 30, "Famosa por sus playas de arena blanca y resorts de lujo. Ideal para actividades acuáticas como snorkel y buceo.", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 2, "Samaná", 30, "Conocida por sus impresionantes paisajes naturales, cascadas y avistamiento de ballenas. La Cascada El Limón es un atractivo popular.", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 3, "Puerto Plata", 30, "Hogar del teleférico de la Loma Isabel de Torres y hermosas playas como Playa Dorada. Ofrece una rica historia colonial.", new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 4, "La Romana", 30, "Conocida por Altos de Chavón, una réplica de un pueblo mediterráneo, y las playas de Bayahibe, que son perfectas para el buceo.", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 5, "Santo Domingo", 30, "La capital del país, rica en historia y cultura. Visita la Zona Colonial, declarada Patrimonio de la Humanidad por la UNESCO.", new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 6, "Isla Saona", 30, "Parte del Parque Nacional del Este, famosa por sus playas vírgenes y aguas turquesas. Ideal para excursiones en catamarán.", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 7, "Jarabacoa", 30, "Conocida como la 'ciudad de la eterna primavera', es perfecta para el ecoturismo, con actividades como rafting y senderismo.", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 8, "Lago Enriquillo", 30, "El lago más grande del Caribe, conocido por su biodiversidad y la posibilidad de ver cocodrilos y flamencos.", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 9, "Parque Nacional Los Haitises", 30, "Un área protegida con manglares, cuevas y una rica fauna. Ideal para excursiones en bote y exploración de la naturaleza.", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 },
                    { 10, "Cabarete", 30, "Famosa por sus deportes acuáticos, especialmente el kitesurf y el windsurf. También ofrece una vibrante vida nocturna.", new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000.0 }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Aprobada" },
                    { 2, "En espera" },
                    { 3, "Rechazada" },
                    { 4, "Abierto" },
                    { 5, "Finalizado" }
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
                table: "EstadosOcupacion",
                columns: new[] { "EstadoOcupacionId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Ocupado" }
                });

            migrationBuilder.InsertData(
                table: "EstadosVencimiento",
                columns: new[] { "EstadoVencimientoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Vigente" },
                    { 2, "Vencida" }
                });

            migrationBuilder.InsertData(
                table: "Guias",
                columns: new[] { "GuiaId", "Nombres", "PrecioGuia" },
                values: new object[,]
                {
                    { 1, "Jorge Ceballos", 5500.0 },
                    { 2, "Alexandra Terrero", 5500.0 },
                    { 3, "Saúl Cremades", 5500.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalles_CarritoId",
                table: "CarritoDetalles",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalles_DestinoId",
                table: "CarritoDetalles",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ClienteId",
                table: "Carritos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AplicationUserId",
                table: "Clientes",
                column: "AplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursiones_ClienteId",
                table: "SolicitudExcursiones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursionesDetalle_DestinoId",
                table: "SolicitudExcursionesDetalle",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudExcursionesDetalle_SolicitudViajeId",
                table: "SolicitudExcursionesDetalle",
                column: "SolicitudViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_GuiaId",
                table: "Viajes",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_SolicitudViajeId",
                table: "Viajes",
                column: "SolicitudViajeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarritoDetalles");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "EstadosDePago");

            migrationBuilder.DropTable(
                name: "EstadosOcupacion");

            migrationBuilder.DropTable(
                name: "EstadosVencimiento");

            migrationBuilder.DropTable(
                name: "SolicitudExcursionesDetalle");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Guias");

            migrationBuilder.DropTable(
                name: "SolicitudExcursiones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
