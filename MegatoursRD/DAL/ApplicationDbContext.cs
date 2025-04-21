using MegatoursRD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MegatoursRD.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<SolicitudViajes> SolicitudExcursiones { get; set; }
        public DbSet<SolicitudViajesDetalle> SolicitudExcursionesDetalle { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<EstadosDePago> EstadosDePago { get; set; }
        public DbSet<Viajes> Viajes { get; set; }
        public DbSet<Guias> Guias { get; set; }
        public DbSet<Destinos> Destinos { get; set; }
        public DbSet<EstadosVencimiento> EstadosVencimiento { get; set; }
        public DbSet<EstadosOcupacion> EstadosOcupacion { get; set; }
		public DbSet<Carrito> Carritos { get; set; }
		public DbSet<CarritoDetalle> CarritoDetalles { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Viajes>()
                .HasOne(v => v.SolicitudViaje)
                .WithMany() // No especificamos lista inversa aquí
                .HasForeignKey(v => v.SolicitudViajeId)
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada

            builder.Entity<SolicitudViajesDetalle>()
                .HasOne(d => d.SolicitudExcursion)
                .WithMany(s => s.ListaDetalles)
                .HasForeignKey(d => d.SolicitudViajeId)
                .OnDelete(DeleteBehavior.Cascade); // Si deseas que los detalles se eliminen junto con la solicitud

            builder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.EstadoId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    // Estados pa las solicitud
                    new Estados { EstadoId = 1, Descripcion = "Aprobada" },
                    new Estados { EstadoId = 2, Descripcion = "En espera" },
                    new Estados { EstadoId = 3, Descripcion = "Rechazada" },

                    // Estados pa los viajes
                    new Estados { EstadoId = 4, Descripcion = "Abierto" },
                    new Estados { EstadoId = 5, Descripcion = "Finalizado" }
                );
            });

            builder.Entity<EstadosVencimiento>(entity =>
            {
                entity.HasKey(e => e.EstadoVencimientoId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    // Estados de vencimiento para solicitud
                    new EstadosVencimiento { EstadoVencimientoId = 1, Descripcion = "Vigente" },
                    new EstadosVencimiento { EstadoVencimientoId = 2, Descripcion = "Vencida" }
                );
            });

            builder.Entity<EstadosDePago>(entity =>
            {
                entity.HasKey(e => e.EstadoPagoId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    // Estados  de pago para viajes
                    new EstadosDePago { EstadoPagoId = 1, Descripcion = "Pagado" },
                    new EstadosDePago { EstadoPagoId = 2, Descripcion = "No pagado" },
                    new EstadosDePago { EstadoPagoId = 3, Descripcion = "Vencido" }
                );
            });

            builder.Entity<EstadosOcupacion>(entity =>
            {
                entity.HasKey(e => e.EstadoOcupacionId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    // Estados de ocupacion para viajes
                    new EstadosOcupacion { EstadoOcupacionId = 1, Descripcion = "Disponible" },
                    new EstadosOcupacion { EstadoOcupacionId = 2, Descripcion = "Ocupado" }
                );
            });

            builder.Entity<Guias>(entity =>
            {
                entity.HasKey(e => e.GuiaId);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    // Estados para viajes
                    new Guias { GuiaId = 1, Nombres = "Jorge Ceballos" },
                    new Guias { GuiaId = 2, Nombres = "Alexandra Terrero" },
                    new Guias { GuiaId = 3, Nombres = "Saúl Cremades" }
                );
            });

            builder.Entity<Clientes>()
               .HasOne(c => c.Usuario)
               .WithMany()
               .HasForeignKey(c => c.AplicationUserId)
               .OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Destinos>().HasData(
                new Destinos
                {
                    DestinoId = 1,
                    Ciudad = "Punta Cana",
                    Descripcion = "Famosa por sus playas de arena blanca y resorts de lujo. Ideal para actividades acuáticas como snorkel y buceo.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 6, 1),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 2,
                    Ciudad = "Samaná",
                    Descripcion = "Conocida por sus impresionantes paisajes naturales, cascadas y avistamiento de ballenas. La Cascada El Limón es un atractivo popular.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 9, 10),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 3,
                    Ciudad = "Puerto Plata",
                    Descripcion = "Hogar del teleférico de la Loma Isabel de Torres y hermosas playas como Playa Dorada. Ofrece una rica historia colonial.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 6, 23),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 4,
                    Ciudad = "La Romana",
                    Descripcion = "Conocida por Altos de Chavón, una réplica de un pueblo mediterráneo, y las playas de Bayahibe, que son perfectas para el buceo.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 8, 11),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 5,
                    Ciudad = "Santo Domingo",
                    Descripcion = "La capital del país, rica en historia y cultura. Visita la Zona Colonial, declarada Patrimonio de la Humanidad por la UNESCO.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 7, 31),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 6,
                    Ciudad = "Isla Saona",
                    Descripcion = "Parte del Parque Nacional del Este, famosa por sus playas vírgenes y aguas turquesas. Ideal para excursiones en catamarán.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 5, 20),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 7,
                    Ciudad = "Jarabacoa",
                    Descripcion = "Conocida como la 'ciudad de la eterna primavera', es perfecta para el ecoturismo, con actividades como rafting y senderismo.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 4, 30),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 8,
                    Ciudad = "Lago Enriquillo",
                    Descripcion = "El lago más grande del Caribe, conocido por su biodiversidad y la posibilidad de ver cocodrilos y flamencos.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 7, 15),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 9,
                    Ciudad = "Parque Nacional Los Haitises",
                    Descripcion = "Un área protegida con manglares, cuevas y una rica fauna. Ideal para excursiones en bote y exploración de la naturaleza.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 12, 10),
					PrecioEntrada = 2000.0,
				},
                new Destinos
                {
                    DestinoId = 10,
                    Ciudad = "Cabarete",
                    Descripcion = "Famosa por sus deportes acuáticos, especialmente el kitesurf y el windsurf. También ofrece una vibrante vida nocturna.",
                    Cupos = 30,
					FechaEstipulada = new DateTime(2025, 11, 11),
					PrecioEntrada = 2000.0,
				}
			);
        }
    }
}