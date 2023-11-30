using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Models.Catalogos;
using RegistroNotas.Models.Cursos;
using RegistroNotas.Models.Estudiantes;

namespace RegistroNotas.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Periodo> Periodos { get; set; } = null!;

    public DbSet<Modalidad> Modalidades { get; set; } = null!;

    public DbSet<Curso> Cursos { get; set; } = null!;
<<<<<<< HEAD

    public DbSet<Docente> Docente { get; set; } = null!;
    public DbSet<CursoMateriasNotas> CursoMateriasNotas { get; set; } = null!;
    public DbSet<Estudiante> Estudiante { get; set; } = null!;
=======
    public DbSet<Estudiante> Estudiantes { get; set; } = null!;
    public DbSet<CursoMateriaNota> CursoMateriasNotas { get; set; } = null!;
    public DbSet<CursoMateria> CursoMaterias { get; set; } = null!;
    public DbSet<CatalogoMateria> CatalogoMateria { get; set; } = null!;
>>>>>>> 616ce103eaa37f8f999e66209a536b29e3d1760e
    public DbSet<CatalogoCurricular> CatalogoCurricular { get; set; } = null!;
    public DbSet<CatalogoDesarrollo> CatalogoDesarrollo { get; set; } = null!;
    public DbSet<CatalogoMateria> CatalogoMateria { get; set; } = null!;
    public DbSet<CursoMaterias> CursoMaterias { get; set; } = null!;
}