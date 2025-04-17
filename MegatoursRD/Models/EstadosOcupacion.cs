using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class EstadosOcupacion
{
    [Key]
    public int EstadoOcupacionId { get; set; }
    public string Descripcion { get; set; }
}
