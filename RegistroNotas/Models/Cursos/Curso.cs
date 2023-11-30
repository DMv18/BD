using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Models.Catalogos;

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

    public  List<Estudiante> Estudiantes { get; set; }= null!;
    public  List<CursoMateriasNotas> CursoMateriasNotas { get; set; }= null!;
    public  List<CursoMaterias> CursoMaterias { get; set; }= null!;

}