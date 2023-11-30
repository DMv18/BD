using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



[Table("CursoMateriasNotas")]

public class CursoMateriasNotas{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(4,2)")]
    public decimal Nota { get; set; }
   
    
}