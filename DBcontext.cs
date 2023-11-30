using Microsoft.EntityFrameworkCore;

namespace DB;

public class DBcontext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Nota> Notas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura el mapeo de la entidad Usuario a la tabla 'usuario'
        modelBuilder.Entity<Usuario>().ToTable("usuario").HasKey(u => u.ID);
    }
}