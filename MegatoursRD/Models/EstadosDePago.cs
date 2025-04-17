using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class EstadosDePago
{
    [Key]
    public int EstadoPagoId { get; set; }
    public string Descripcion { get; set; }
}
