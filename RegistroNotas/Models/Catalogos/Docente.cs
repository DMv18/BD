using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroNotas.Models.Catalogos;

[Table("Docente")]
public class Docente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Primer_Nombre { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Segundo_Nombre { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Primer_Apellido { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Segundo_Apellido { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public bool Activo { get; set; }
}