using MegatoursRD.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegatoursRD.Models;

public class Clientes
{
	[Key]
	public int ClienteId { get; set; }
	[ForeignKey("Id")]
	public string AplicationUserId { get; set; } = null!;
	public ApplicationUser? Usuario { get; set; } = null!;
	[Required]
	public string Nombre { get; set; } = null!;
}
