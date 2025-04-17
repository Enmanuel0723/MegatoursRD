using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class SolicitudViajes

{
	[Key]
	public int SolicitudViajeId { get; set; }
	public int EstadoId { get; set; }
	public int EstadoVencimientoId { get; set; }
	public int EstadoOcupacionId { get; set; }
	public int ClienteId { get; set; }
	public Clientes? Cliente { get; set; }
    public int IdDestino { get; set; }
    public DateTime FechaEstipulada { get; set; }
	public int CantAdultos { get; set; }
	public int CantNinos { get; set; }
	public string Asunto { get; set; }
	public string? Nota { get; set; }
	public double Precio { get; set; } = 0;
    public List<SolicitudViajesDetalle> ListaDetalles { get; set; } = new();
}
