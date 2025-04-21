using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegatoursRD.Models;

public class Destinos
{
    [Key]
    public int DestinoId { get; set; }
    public string Ciudad { get; set; }
    public string Descripcion { get; set; }
    public int Cupos { get; set; }
    public DateTime FechaEstipulada { get; set; } = DateTime.Now;
	public double PrecioEntrada { get; set; }
	public string? ImagenUrl { get; set; }
	[NotMapped]
	[Range(0, int.MaxValue, ErrorMessage = "No se permiten valores negativos.")]
	public int CantNinos { get; set; }
	[NotMapped]
	[Range(0, int.MaxValue, ErrorMessage = "No se permiten valores negativos.")]
	public int CantAdultos { get; set; }
}
