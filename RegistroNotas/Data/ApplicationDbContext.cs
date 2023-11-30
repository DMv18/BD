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

    public DbSet<Docente> Docente { get; set; } = null!;

    public DbSet<CursoMateriaNota> CursoMateriasNotas { get; set; } = null!;

    public DbSet<Estudiante> Estudiantes { get; set; } = null!;

    public DbSet<CursoMateria> CursoMaterias { get; set; } = null!;

    public DbSet<CatalogoCurricular> CatalogoCurriculares { get; set; } = null!;

    public DbSet<CatalogoDesarrollo> CatalogoDesarrollos { get; set; } = null!;

    public DbSet<CatalogoMateria> CatalogoMaterias { get; set; } = null!;
}