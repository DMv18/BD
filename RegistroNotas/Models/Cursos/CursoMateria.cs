using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD


[Table("CursoMaterias")]

public class CursoMaterias{
    [Key]
    public int Id { get; set; }
    public  List<CursoMateriasNotas> CursoMateriasNotas { get; set; }= null!;
    public CatalogoMateria CatalogoMateria { get; set; } = null!;
=======
using RegistroNotas.Models.Catalogos;

namespace RegistroNotas.Models.Cursos;

[Table("CursoMaterias")]
public class CursoMateria
{
    [Key]
    public int Id { get; set; }

    public Curso Curso { get; set; } = null!;

    public CatalogoMateria Materia { get; set; } = null!;
>>>>>>> 616ce103eaa37f8f999e66209a536b29e3d1760e
}