using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Estante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstante { get; set; }
        public string DescripcionEstante { get; set; } = null!;
        [ForeignKey("IdEstanteria")]
        public int IdEstanteria { get; set; }
        //public Estanteria IdEstanteriaNavigation { get; set; } = null!;
        public ICollection<Seccion> Secciones { get; set; } = new List<Seccion>();
    }
}
