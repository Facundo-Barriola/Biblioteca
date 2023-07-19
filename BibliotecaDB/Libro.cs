using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BibliotecaDB 
{ 
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }

        public string Titulo { get; set; }

        public string Sinopsis { get; set; }

        public int PuntajeCritica { get; set; }

        public int Estado { get; set; }

        public bool Disponibilidad { get; set; }

        public int IdSeccion { get; set; }
        [ForeignKey("IdSeccion")]
        public Seccion IdSeccionNavigation { get; set; } = null!;
        public ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();

        }
    }



