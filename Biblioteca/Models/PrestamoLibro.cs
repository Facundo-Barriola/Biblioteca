using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class PrestamoLibro
{
    public int IdPrestamoLibro { get; set; }

    public int IdPrestamo { get; set; }

    public int IdLibro { get; set; }

    public Libro IdLibroNavigation { get; set; } = null!;

    public Prestamo IdPrestamoNavigation { get; set; } = null!;
}
