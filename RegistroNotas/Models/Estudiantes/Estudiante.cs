using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD:RegistroNotas/Models/Estudiante/Estudiante.cs

=======
using RegistroNotas.Models.Cursos;

namespace RegistroNotas.Models.Estudiantes;
>>>>>>> 616ce103eaa37f8f999e66209a536b29e3d1760e:RegistroNotas/Models/Estudiantes/Estudiante.cs

[Table("Estudiantes")]
public class Estudiante
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Primer_Nombre { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Segundo_Nombre { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Primer_Apellido { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Segundo_Apellido { get; set; } = null!;
<<<<<<< HEAD:RegistroNotas/Models/Estudiante/Estudiante.cs
    public bool Activo { get; set; }
    public List<CursoMateriasNotas> CursoMateriasNotas { get; set; } = null!;
    
=======

    public bool Activo { get; set; }
    public required List<CursoMateriaNota> CursoMateriasNotas { get; set; }
>>>>>>> 616ce103eaa37f8f999e66209a536b29e3d1760e:RegistroNotas/Models/Estudiantes/Estudiante.cs
}