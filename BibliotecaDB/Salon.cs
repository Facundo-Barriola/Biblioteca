using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class Salon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSalon { get; set; }

        public string DescripcionSalon { get; set; } = null!;

        public ICollection<Estanteria> Estanteria { get; set; } = new List<Estanteria>();
    }
}
