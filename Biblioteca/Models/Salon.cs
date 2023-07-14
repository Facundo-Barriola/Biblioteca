using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Salon
{
    public int IdSalon { get; set; }

    public string DescripcionSalon { get; set; } = null!;

    public virtual ICollection<Estanterium> Estanteria { get; set; } = new List<Estanterium>();
}
