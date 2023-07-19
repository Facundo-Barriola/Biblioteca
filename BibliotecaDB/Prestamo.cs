using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Prestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrestamo { get; set; }
        public DateTime? FechaExtraccion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaPactada { get; set; }
        public bool? EstadoPrestamo { get; set; }
        [ForeignKey("IdUsuario")]
        public string IdUsuario { get; set; } = null!;
        
        //public Usuario IdUsuarioNavigation { get; set; } = null!;

        public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();
    }
}
