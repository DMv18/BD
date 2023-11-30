using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Models.Catalogos;
using RegistroNotas.Models.Estudiantes;

namespace RegistroNotas.Models.Cursos;

[Table("Cursos")]
public class Curso
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Grado { get; set; }

    public Periodo Periodo { get; set; } = null!;

    public Modalidad Modalidad { get; set; } = null!;
    public Docente Docente { get; set; } = null!;

    public List<Estudiante> Estudiantes { get; set; } = null!;
    public List<CursoMateriaNota> CursoMateriasNotas { get; set; } = null!;
    public List<CursoMateria> CursoMaterias { get; set; } = null!;
}