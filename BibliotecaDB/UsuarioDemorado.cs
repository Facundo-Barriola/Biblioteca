using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class UsuarioDemorado
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public DateTime? FechaExtraccion { get; set; }
        public DateTime FechaPactada { get; set; }
        public int? DiasRetrasado { get; set; }
    }
}
