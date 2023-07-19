using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Estanteria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstanteria { get; set; }

        public string DescripcionEstanteria { get; set; } = null!;

        public int IdSalon { get; set; }
        [ForeignKey("IdSalon")]
        public ICollection<Estante> Estantes { get; set; } = new List<Estante>();

        public Salon IdSalonNavigation { get; set; } = null!;
    }
}
