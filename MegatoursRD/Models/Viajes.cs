using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegatoursRD.Models;

public class Viajes
{
    [Key]
    public int ViajeId { get; set; }
    public int EstadoId { get; set; }
    public int EstadoPagoId { get; set; }
    public int? GuiaId { get; set; }
    public Guias? Guia { get; set; }
    public int? SolicitudViajeId { get; set; }
    [ForeignKey("SolicitudViajeId")]
    public SolicitudViajes? SolicitudViaje { get; set; } = new();
    public double PrecioFinal { get; set; } = 3500.0;
	public int? ClienteId { get; set; }
    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set; }
	public DateTime? FechaEstipulada { get; set; }
	public int? CantNinos { get; set; }
	public int? CantAdultos { get; set; }
}
