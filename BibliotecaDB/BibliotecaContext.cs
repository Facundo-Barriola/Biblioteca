using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Libro>().ToTable("Libro");
        }

    }
}