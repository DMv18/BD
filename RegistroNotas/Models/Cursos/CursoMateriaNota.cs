using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Models.Estudiantes;

namespace RegistroNotas.Models.Cursos;

[Table("CursoMateriasNotas")]
public class CursoMateriaNota
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(4,2)")]
    public decimal Nota { get; set; }

    public Curso Curso { get; set; } = null!;

    public CursoMateria CursoMateria { get; set; } = null!;

    public Estudiante Estudiante { get; set; } = null!;
}