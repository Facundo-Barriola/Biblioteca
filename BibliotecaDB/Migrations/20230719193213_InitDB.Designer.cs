﻿// <auto-generated />
using System;
using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaDB.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    [Migration("20230719193213_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaDB.Estante", b =>
                {
                    b.Property<int>("IdEstante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstante"));

                    b.Property<string>("DescripcionEstante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstanteriaIdEstanteria")
                        .HasColumnType("int");

                    b.Property<int>("IdEstanteria")
                        .HasColumnType("int");

                    b.HasKey("IdEstante");

                    b.HasIndex("EstanteriaIdEstanteria");

                    b.ToTable("Estantes");
                });

            modelBuilder.Entity("BibliotecaDB.Estanteria", b =>
                {
                    b.Property<int>("IdEstanteria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstanteria"));

                    b.Property<string>("DescripcionEstanteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSalon")
                        .HasColumnType("int");

                    b.Property<int?>("SalonIdSalon")
                        .HasColumnType("int");

                    b.HasKey("IdEstanteria");

                    b.HasIndex("SalonIdSalon");

                    b.ToTable("Estanterias");
                });

            modelBuilder.Entity("BibliotecaDB.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdSeccion")
                        .HasColumnType("int");

                    b.Property<int>("PuntajeCritica")
                        .HasColumnType("int");

                    b.Property<int?>("SeccionIdSeccion")
                        .HasColumnType("int");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLibro");

                    b.HasIndex("SeccionIdSeccion");

                    b.ToTable("Libro", (string)null);
                });

            modelBuilder.Entity("BibliotecaDB.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"));

                    b.Property<bool?>("EstadoPrestamo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaExtraccion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPactada")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("BibliotecaDB.PrestamoLibro", b =>
                {
                    b.Property<int>("IdPrestamoLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamoLibro"));

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<int?>("LibroIdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("PrestamoIdPrestamo")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamoLibro");

                    b.HasIndex("LibroIdLibro");

                    b.HasIndex("PrestamoIdPrestamo");

                    b.ToTable("PrestamoLibros");
                });

            modelBuilder.Entity("BibliotecaDB.Salon", b =>
                {
                    b.Property<int>("IdSalon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSalon"));

                    b.Property<string>("DescripcionSalon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSalon");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("BibliotecaDB.Seccion", b =>
                {
                    b.Property<int>("IdSeccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSeccion"));

                    b.Property<string>("DescripcionSeccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstanteIdEstante")
                        .HasColumnType("int");

                    b.Property<int>("IdEstante")
                        .HasColumnType("int");

                    b.HasKey("IdSeccion");

                    b.HasIndex("EstanteIdEstante");

                    b.ToTable("Secciones");
                });

            modelBuilder.Entity("BibliotecaDB.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Tipo")
                        .HasColumnType("bit");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BibliotecaDB.Estante", b =>
                {
                    b.HasOne("BibliotecaDB.Estanteria", null)
                        .WithMany("Estantes")
                        .HasForeignKey("EstanteriaIdEstanteria");
                });

            modelBuilder.Entity("BibliotecaDB.Estanteria", b =>
                {
                    b.HasOne("BibliotecaDB.Salon", null)
                        .WithMany("Estanteria")
                        .HasForeignKey("SalonIdSalon");
                });

            modelBuilder.Entity("BibliotecaDB.Libro", b =>
                {
                    b.HasOne("BibliotecaDB.Seccion", null)
                        .WithMany("Libros")
                        .HasForeignKey("SeccionIdSeccion");
                });

            modelBuilder.Entity("BibliotecaDB.Prestamo", b =>
                {
                    b.HasOne("BibliotecaDB.Usuario", null)
                        .WithMany("Prestamos")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("BibliotecaDB.PrestamoLibro", b =>
                {
                    b.HasOne("BibliotecaDB.Libro", null)
                        .WithMany("PrestamoLibros")
                        .HasForeignKey("LibroIdLibro");

                    b.HasOne("BibliotecaDB.Prestamo", null)
                        .WithMany("PrestamoLibros")
                        .HasForeignKey("PrestamoIdPrestamo");
                });

            modelBuilder.Entity("BibliotecaDB.Seccion", b =>
                {
                    b.HasOne("BibliotecaDB.Estante", null)
                        .WithMany("Secciones")
                        .HasForeignKey("EstanteIdEstante");
                });

            modelBuilder.Entity("BibliotecaDB.Estante", b =>
                {
                    b.Navigation("Secciones");
                });

            modelBuilder.Entity("BibliotecaDB.Estanteria", b =>
                {
                    b.Navigation("Estantes");
                });

            modelBuilder.Entity("BibliotecaDB.Libro", b =>
                {
                    b.Navigation("PrestamoLibros");
                });

            modelBuilder.Entity("BibliotecaDB.Prestamo", b =>
                {
                    b.Navigation("PrestamoLibros");
                });

            modelBuilder.Entity("BibliotecaDB.Salon", b =>
                {
                    b.Navigation("Estanteria");
                });

            modelBuilder.Entity("BibliotecaDB.Seccion", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("BibliotecaDB.Usuario", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
