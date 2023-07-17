using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class BibliotecaContext : DbContext
{

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estante> Estantes { get; set; }

    public virtual DbSet<Estanteria> Estanteria { get; set; }

    public virtual DbSet<InformacionLibro> InformacionLibros { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<PrestamoLibro> PrestamoLibros { get; set; }

    public virtual DbSet<PrestamosDeLibro> PrestamosDeLibros { get; set; }

    public virtual DbSet<Salon> Salons { get; set; }

    public virtual DbSet<Seccion> Seccions { get; set; }

    public virtual DbSet<UbicacionLibro> UbicacionLibros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosDemorado> UsuariosDemorados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Biblioteca; Trusted_Connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estante>(entity =>
        {
            entity.HasKey(e => e.IdEstante).HasName("PK__estante__3CBB3E3B09EBCF84");

            entity.ToTable("estante");

            entity.Property(e => e.IdEstante).HasColumnName("id_estante");
            entity.Property(e => e.DescripcionEstante)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_estante");
            entity.Property(e => e.IdEstanteria).HasColumnName("id_estanteria");

            entity.HasOne(d => d.IdEstanteriaNavigation).WithMany(p => p.Estantes)
                .HasForeignKey(d => d.IdEstanteria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdEstanteria");
        });

        modelBuilder.Entity<Estanteria>(entity =>
        {
            entity.HasKey(e => e.IdEstanteria).HasName("PK__estanter__A1D9749C4910135A");

            entity.ToTable("estanteria");

            entity.Property(e => e.IdEstanteria).HasColumnName("id_estanteria");
            entity.Property(e => e.DescripcionEstanteria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_estanteria");
            entity.Property(e => e.IdSalon).HasColumnName("id_salon");

            entity.HasOne(d => d.IdSalonNavigation).WithMany(p => p.Estanteria)
                .HasForeignKey(d => d.IdSalon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdSalon");
        });

        modelBuilder.Entity<InformacionLibro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("informacionLibros");

            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.PuntajeCritica).HasColumnName("puntaje_critica");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__libro__EC09C24EF4E0BFF9");

            entity.ToTable("libro");

            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.PuntajeCritica)
                .HasDefaultValueSql("((0))")
                .HasColumnName("puntaje_critica");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdSeccion");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__prestamo__5E87BE27CFD130DE");

            entity.ToTable("prestamo");

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.EstadoPrestamo).HasColumnName("estado_prestamo");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("date")
                .HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaExtraccion)
                .HasColumnType("date")
                .HasColumnName("fecha_extraccion");
            entity.Property(e => e.FechaPactada)
                .HasColumnType("date")
                .HasColumnName("fecha_pactada");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Idsuario");
        });

        modelBuilder.Entity<PrestamoLibro>(entity =>
        {
            entity.HasKey(e => e.IdPrestamoLibro);

            entity.ToTable("prestamo_libro");

            entity.Property(e => e.IdPrestamoLibro).HasColumnName("id_prestamo_libro");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.PrestamoLibros)
                .HasForeignKey(d => d.IdLibro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdLibro");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.PrestamoLibros)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdPrestamo");
        });

        modelBuilder.Entity<PrestamosDeLibro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("prestamosDeLibros");

            entity.Property(e => e.Apellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.EstadoPrestamo).HasColumnName("estado_prestamo");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("date")
                .HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaExtraccion)
                .HasColumnType("date")
                .HasColumnName("fecha_extraccion");
            entity.Property(e => e.FechaPactada)
                .HasColumnType("date")
                .HasColumnName("fecha_pactada");
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.IdSalon).HasName("PK__salon__6C454F24AF1A9901");

            entity.ToTable("salon");

            entity.Property(e => e.IdSalon).HasColumnName("id_salon");
            entity.Property(e => e.DescripcionSalon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_salon");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__seccion__7C91FD810DFF76E6");

            entity.ToTable("seccion");

            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.DescripcionSeccion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_seccion");
            entity.Property(e => e.IdEstante).HasColumnName("id_estante");

            entity.HasOne(d => d.IdEstanteNavigation).WithMany(p => p.Seccions)
                .HasForeignKey(d => d.IdEstante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdEstante");
        });

        modelBuilder.Entity<UbicacionLibro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ubicacionLibro");

            entity.Property(e => e.DescripcionEstante)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_estante");
            entity.Property(e => e.DescripcionEstanteria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_estanteria");
            entity.Property(e => e.DescripcionSalon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_salon");
            entity.Property(e => e.DescripcionSeccion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("descripcion_seccion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PK__usuario__D87608A6948E5053");

            entity.ToTable("usuario");

            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Apellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Mail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
        });

        modelBuilder.Entity<UsuariosDemorado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("usuariosDemorados");

            entity.Property(e => e.Apellido)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.DiasRetrasado).HasColumnName("dias_retrasado");
            entity.Property(e => e.FechaExtraccion)
                .HasColumnType("date")
                .HasColumnName("fecha_extraccion");
            entity.Property(e => e.FechaPactada)
                .HasColumnType("date")
                .HasColumnName("fecha_pactada");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
