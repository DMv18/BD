using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroNotas.Models.Catalogos;

[Table("CatalogoCurricular")]
public class CatalogoCurricular
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }
<<<<<<< HEAD
    
   
=======
>>>>>>> 616ce103eaa37f8f999e66209a536b29e3d1760e
}