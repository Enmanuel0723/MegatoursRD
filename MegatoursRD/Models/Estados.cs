using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class Estados
{
	[Key]
	public int EstadoId { get; set; }
	public string Descripcion { get; set; }
}
