using MegatoursRD.Models;
using System.ComponentModel.DataAnnotations;

public class Carrito
{
	[Key]
	public int CarritoId { get; set; }

	public int? ClienteId { get; set; }
	public Clientes? Cliente { get; set; }

	public DateTime FechaCreacion { get; set; } = DateTime.Now;

	public string? SesionAnonimaId { get; set; }

	public List<CarritoDetalle> Detalles { get; set; } = new();
}
