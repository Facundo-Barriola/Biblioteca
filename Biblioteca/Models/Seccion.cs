using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public string DescripcionSeccion { get; set; } = null!;

    public int IdEstante { get; set; }

    public virtual Estante IdEstanteNavigation { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
