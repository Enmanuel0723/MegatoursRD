using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class SolicitudViajesDetalle
{
	[Key]
	public int DetalleId { get; set; }
    public int SolicitudViajeId { get; set; }
    public SolicitudViajes? SolicitudExcursion { get; set; }
    public int DestinoId { get; set; }
    public Destinos? Destino { get; set; }
    public string Ciudad { get; set; }
    public string Descripcion { get; set; }
    public int CantAdultos { get; set; }
    public int CantNinos { get; set; }
    public double PrecioAdultos { get; set; }
	public double PrecioNinos { get; set; }
}
