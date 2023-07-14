using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Libro
{
    public int IdLibro { get; set; }

    public string Titulo { get; set; } = null!;

    public string Sinopsis { get; set; } = null!;

    public int? PuntajeCritica { get; set; }

    public int Estado { get; set; }

    public bool? Disponibilidad { get; set; }

    public int IdSeccion { get; set; }

    public Seccion IdSeccionNavigation { get; set; } = null!;

    public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();
}
