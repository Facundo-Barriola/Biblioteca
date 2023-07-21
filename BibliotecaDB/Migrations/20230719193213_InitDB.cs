using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDB.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    IdSalon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionSalon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.IdSalon);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Estanterias",
                columns: table => new
                {
                    IdEstanteria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEstanteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSalon = table.Column<int>(type: "int", nullable: false),
                    SalonIdSalon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estanterias", x => x.IdEstanteria);
                    table.ForeignKey(
                        name: "FK_Estanterias_Salones_SalonIdSalon",
                        column: x => x.SalonIdSalon,
                        principalTable: "Salones",
                        principalColumn: "IdSalon");
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaExtraccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPactada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoPrestamo = table.Column<bool>(type: "bit", nullable: true),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Estantes",
                columns: table => new
                {
                    IdEstante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEstante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstanteria = table.Column<int>(type: "int", nullable: false),
                    EstanteriaIdEstanteria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estantes", x => x.IdEstante);
                    table.ForeignKey(
                        name: "FK_Estantes_Estanterias_EstanteriaIdEstanteria",
                        column: x => x.EstanteriaIdEstanteria,
                        principalTable: "Estanterias",
                        principalColumn: "IdEstanteria");
                });

            migrationBuilder.CreateTable(
                name: "Secciones",
                columns: table => new
                {
                    IdSeccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionSeccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstante = table.Column<int>(type: "int", nullable: false),
                    EstanteIdEstante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secciones", x => x.IdSeccion);
                    table.ForeignKey(
                        name: "FK_Secciones_Estantes_EstanteIdEstante",
                        column: x => x.EstanteIdEstante,
                        principalTable: "Estantes",
                        principalColumn: "IdEstante");
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntajeCritica = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    IdSeccion = table.Column<int>(type: "int", nullable: false),
                    SeccionIdSeccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Secciones_SeccionIdSeccion",
                        column: x => x.SeccionIdSeccion,
                        principalTable: "Secciones",
                        principalColumn: "IdSeccion");
                });

            migrationBuilder.CreateTable(
                name: "PrestamoLibros",
                columns: table => new
                {
                    IdPrestamoLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    LibroIdLibro = table.Column<int>(type: "int", nullable: true),
                    PrestamoIdPrestamo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamoLibros", x => x.IdPrestamoLibro);
                    table.ForeignKey(
                        name: "FK_PrestamoLibros_Libro_LibroIdLibro",
                        column: x => x.LibroIdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK_PrestamoLibros_Prestamos_PrestamoIdPrestamo",
                        column: x => x.PrestamoIdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estanterias_SalonIdSalon",
                table: "Estanterias",
                column: "SalonIdSalon");

            migrationBuilder.CreateIndex(
                name: "IX_Estantes_EstanteriaIdEstanteria",
                table: "Estantes",
                column: "EstanteriaIdEstanteria");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_SeccionIdSeccion",
                table: "Libro",
                column: "SeccionIdSeccion");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoLibros_LibroIdLibro",
                table: "PrestamoLibros",
                column: "LibroIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamoLibros_PrestamoIdPrestamo",
                table: "PrestamoLibros",
                column: "PrestamoIdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioIdUsuario",
                table: "Prestamos",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Secciones_EstanteIdEstante",
                table: "Secciones",
                column: "EstanteIdEstante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestamoLibros");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Secciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estantes");

            migrationBuilder.DropTable(
                name: "Estanterias");

            migrationBuilder.DropTable(
                name: "Salones");
        }
    }
}
