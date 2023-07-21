using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Usuario
{
    public string Dni { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool? Tipo { get; set; }

    private ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
