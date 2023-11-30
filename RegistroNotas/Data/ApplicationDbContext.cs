using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Models.Catalogos;
using RegistroNotas.Models.Cursos;

namespace RegistroNotas.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{


    public DbSet<Docente> Docentes { get; set; } = null!;
    public DbSet<Modalidad> Modalidades { get; set; } = null!;
    public DbSet<Periodo> Periodos { get; set; } = null!;
    public DbSet<Curso> Cursos { get; set; } = null!;
    public DbSet<Estudiante> Estudiantes { get; set; } = null!;
    public DbSet<CursoMateriasNotas> CursoMateriasNotas { get; set; } = null!;
    public DbSet<CursoMaterias> CursoMaterias { get; set; } = null!;
    public DbSet<CatalogoMateria> CatalogoMateria { get; set; } = null!;
    public DbSet<CatalogoCurricular> CatalogoCurricular { get; set; } = null!;
    public DbSet<CatalogoDesarrollo> CatalogoDesarrollo { get; set; } = null!;
    
}
