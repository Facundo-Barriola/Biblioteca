﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class PrestamosDeLibro
    {
        public string Titulo { get; set; } = null!;
        public DateTime? FechaExtraccion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaPactada { get; set; }
        public bool? EstadoPrestamo { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}