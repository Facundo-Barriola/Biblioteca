using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class UsuariosDemorado
{
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public DateTime? FechaExtraccion { get; set; }

    public DateTime FechaPactada { get; set; }

    public int? DiasRetrasado { get; set; }
}
