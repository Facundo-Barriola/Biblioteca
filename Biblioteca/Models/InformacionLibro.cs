using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class InformacionLibro
{
    public string Titulo { get; set; } = null!;

    public string Sinopsis { get; set; } = null!;

    public int? PuntajeCritica { get; set; }

    public int Estado { get; set; }

    public bool? Disponibilidad { get; set; }
}
