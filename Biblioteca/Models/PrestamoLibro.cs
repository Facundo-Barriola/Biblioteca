using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class PrestamoLibro
{
    public int IdPrestamoLibro { get; set; }

    public int IdPrestamo { get; set; }

    public int IdLibro { get; set; }

    private Libro IdLibroNavigation { get; set; } = null!;

    private Prestamo IdPrestamoNavigation { get; set; } = null!;
}
