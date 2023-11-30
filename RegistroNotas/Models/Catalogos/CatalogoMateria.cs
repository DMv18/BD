using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroNotas.Models.Catalogos;

[Table("CatalogoMateria")]
public class CatalogoMateria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }
    public int Parciales { get; set; }

    public Docente Docente { get; set; } = null!;
    public CatalogoCurricular CatalogoCurricular { get; set; } = null!;
}