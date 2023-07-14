using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Estante
{
    public int IdEstante { get; set; }

    public string DescripcionEstante { get; set; } = null!;

    public int IdEstanteria { get; set; }

    public Estanteria IdEstanteriaNavigation { get; set; } = null!;

    public ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
