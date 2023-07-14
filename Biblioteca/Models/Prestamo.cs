﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; }

    public DateTime? FechaExtraccion { get; set; }

    public DateTime FechaDevolucion { get; set; }

    public DateTime FechaPactada { get; set; }

    public bool? EstadoPrestamo { get; set; }

    public string IdUsuario { get; set; } = null!;

    public Usuario IdUsuarioNavigation { get; set; } = null!;

    public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();
}
