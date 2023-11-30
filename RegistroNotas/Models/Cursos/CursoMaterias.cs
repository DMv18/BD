using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("CursoMaterias")]

public class CursoMaterias{
    [Key]
    public int Id { get; set; }
    
}