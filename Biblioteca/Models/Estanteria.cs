using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Estanteria
{
    public int IdEstanteria { get; set; }

    public string DescripcionEstanteria { get; set; } = null!;

    public int IdSalon { get; set; }

    public ICollection<Estante> Estantes { get; set; } = new List<Estante>();

    //public Salon IdSalonNavigation { get; set; } = null!;
}
