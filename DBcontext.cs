using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Configura la cadena de conexión a tu base de datos
    optionsBuilder.UseSqlServer("Server=VICTUS\\SQLEXPRESS;Database=Prueba;User Id=David;Password=Contrasena123;TrustServerCertificate=True;");
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configura el mapeo de la entidad Usuario a la tabla 'usuario'
    modelBuilder.Entity<Usuario>().ToTable("usuario").HasKey(u => u.ID);
}
    }
}