using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Estanterium
{
    public int IdEstanteria { get; set; }

    public string DescripcionEstanteria { get; set; } = null!;

    public int IdSalon { get; set; }

    public virtual ICollection<Estante> Estantes { get; set; } = new List<Estante>();

    public virtual Salon IdSalonNavigation { get; set; } = null!;
}
