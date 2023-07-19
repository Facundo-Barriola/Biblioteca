using Microsoft.EntityFrameworkCore;

namespace BibliotecaDB
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
            
        }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Estanteria> Estanterias { get; set; }
        public DbSet<Estante> Estantes { get; set;}
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set;}
        public DbSet<PrestamoLibro> PrestamoLibros { get;set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PrestamosDeLibro> PrestamosDeLibros { get; set; }
        public DbSet<UsuarioDemorado> UsuariosDemorados { get; set; }
        public DbSet<UbicacionLibro> UbicacionLibros { get; set; }

    }
}