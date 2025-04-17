using System.ComponentModel.DataAnnotations;

namespace MegatoursRD.Models;

public class Destinos
{
    [Key]
    public int DestinoId { get; set; }
    public string Ciudad { get; set; }
    public string Descripcion { get; set; }
    public int Cupos { get; set; }
}
