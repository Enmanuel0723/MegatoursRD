using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class Guias
{
    [Key]
    public int GuiaId { get; set; }
    public string Nombres { get; set; }
    public double PrecioGuia { get; set; } = 5500.0;
}
