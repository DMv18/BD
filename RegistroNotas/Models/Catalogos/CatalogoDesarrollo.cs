using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("CatalogoDesarrollo")]

public class CatalogoDesarrollo{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Descripcion { get; set; } = null!;
    public bool Activo { get; set; }
    public List<CatalogoCurricular> CatalogoCurricular { get; set; } = null!;
   
}