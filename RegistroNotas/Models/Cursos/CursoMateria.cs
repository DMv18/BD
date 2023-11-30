using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("CursoMaterias")]

public class CursoMaterias{
    [Key]
    public int Id { get; set; }
    public  List<CursoMateriasNotas> CursoMateriasNotas { get; set; }= null!;
    public CatalogoMateria CatalogoMateria { get; set; } = null!;
}