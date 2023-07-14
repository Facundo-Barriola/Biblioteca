using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Estante
{
    public int IdEstante { get; set; }

    public string DescripcionEstante { get; set; } = null!;

    public int IdEstanteria { get; set; }

    public virtual Estanterium IdEstanteriaNavigation { get; set; } = null!;

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
