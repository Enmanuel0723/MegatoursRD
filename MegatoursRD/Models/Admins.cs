using MegatoursRD.Data;
using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class Admins
{
	[Key]
	public int AdminId { get; set; }
	public string ApplicationUserId { get; set; } = null!;
	public ApplicationUser Usuario { get; set; } = null!;
	[Required]
	public string Nombre { get; set; } = null!;
	[Required]
	public DateTime FechaIngreso { get; set; } = DateTime.Now;
}
