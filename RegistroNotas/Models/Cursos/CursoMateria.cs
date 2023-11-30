using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Models.Catalogos;

namespace RegistroNotas.Models.Cursos;

[Table("CursoMaterias")]
public class CursoMateria
{
    [Key]
    public int Id { get; set; }

    public Docente Docente { get; set; } = null!;

    public CatalogoMateria Materia { get; set; } = null!;

    public List<CursoMateriaNota> CursoMateriaNotas { get; set; } = new();
}