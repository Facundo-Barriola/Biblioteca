using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class UbicacionLibro
    {
        public string Titulo { get; set; } = null!;
        public string DescripcionSalon { get; set; } = null!;
        public string DescripcionEstanteria { get; set; } = null!;
        public string DescripcionEstante { get; set; } = null!;
        public string DescripcionSeccion { get; set; } = null!;
    }
}
