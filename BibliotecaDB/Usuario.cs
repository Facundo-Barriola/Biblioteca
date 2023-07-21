using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public bool? Tipo { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
