using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class EstadosVencimiento
{
    [Key]
    public int EstadoVencimientoId { get; set; }
    public string Descripcion { get; set; }
}