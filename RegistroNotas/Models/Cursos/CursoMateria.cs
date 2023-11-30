using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Models.Catalogos;

namespace RegistroNotas.Models.Cursos;

[Table("CursoMaterias")]
public class CursoMateria
{
    [Key]
    public int Id { get; set; }

    public Curso Curso { get; set; } = null!;

    public CatalogoMateria Materia { get; set; } = null!;
}