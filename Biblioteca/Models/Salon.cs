using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Salon
{
    public int IdSalon { get; set; }
    public string DescripcionSalon { get; set; } = null!;
    public ICollection<Estanteria> Estanterias { get; set; } = new List<Estanteria>();

    public Salon(int idSalon, string descripcionSalon)
    {
        IdSalon = idSalon;
        DescripcionSalon = descripcionSalon;
    }

    public void UpdateIdSalon(int newIdSalon)
    {
        IdSalon = newIdSalon;
    }

    public void UpdateDescripcionSalon(string newDescripcionSalon)
    {
        DescripcionSalon = newDescripcionSalon;
    }
}

