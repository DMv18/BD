using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistroNotas.Migrations;

[Table("Estudiantes")]

public class Estudiante{
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
    public bool Activo { get; set; }
    public required List<CursoMateriasNotas> CursoMateriasNotas { get; set; }
    

}