using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasBiblioteca.Models
{
    public class Libro
    {  
        public int IdLibro { get; set; }

        public string Titulo { get; set; }

        public string Sinopsis { get; set; }

        public int PuntajeCritica { get; set; }

        public int Estado { get; set; }

        public bool Disponibilidad { get; set; }

        public int IdSeccion { get; set; }

    }
    
}
