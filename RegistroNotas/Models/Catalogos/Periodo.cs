using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroNotas.Models.Catalogos;

[Table("Periodos")]
public class Periodo
{
    [Key]
    public int Id { get; set; }

    public int Valor { get; set; }
    public bool Activo { get; set; }
}