﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDB
{
    public class PrestamoLibro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrestamoLibro { get; set; }
        [ForeignKey("IdPrestamo")]
        public int IdPrestamo { get; set; }
        
        [ForeignKey("IdLibro")]
        public int IdLibro { get; set; }
        
        //public Libro IdLibroNavigation { get; set; } = null!;
        //public Prestamo IdPrestamoNavigation { get; set; } = null!;
    }
}
