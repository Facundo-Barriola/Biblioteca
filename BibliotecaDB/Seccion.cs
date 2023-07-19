using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Seccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSeccion { get; set; }
        public string DescripcionSeccion { get; set; } = null!;
        [ForeignKey("IdEstante")]
        public int IdEstante { get; set; }
        
        //public Estante IdEstanteNavigation { get; set; } = null!;

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
