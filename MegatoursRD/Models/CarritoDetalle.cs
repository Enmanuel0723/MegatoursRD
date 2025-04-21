using MegatoursRD.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CarritoDetalle
{
	[Key]
	public int CarritoDetalleId { get; set; }

	public int CarritoId { get; set; }
	public Carrito? Carrito { get; set; }

	public int DestinoId { get; set; }
	public Destinos? Destino { get; set; }

	public int CantAdultos { get; set; }
	public int CantNinos { get; set; }

	public double PrecioAdultos { get; set; }
	public double PrecioNinos { get; set; }

	[NotMapped]
	public double Total => (CantAdultos * PrecioAdultos) + (CantNinos * PrecioNinos);
}
