using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class PrestamoLibro
{
    public int IdPrestamoLibro { get; set; }

    public int IdPrestamo { get; set; }

    public int IdLibro { get; set; }

    public virtual Libro IdLibroNavigation { get; set; } = null!;

    public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
}
