using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroNotas.Models.Catalogos;

[Table("Modalidades")]
public class Modalidad
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Valor { get; set; } = null!;

    public bool Activo { get; set; }
}