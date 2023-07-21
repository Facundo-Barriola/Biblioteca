using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Seccion
{
    public int IdSeccion { get; set; }

    public string DescripcionSeccion { get; set; } = null!;

    public int IdEstante { get; set; }

    private Estante IdEstanteNavigation { get; set; } = null!;

    private ICollection<Libro> Libros { get; set; } = new List<Libro>();

    public Seccion(int idSeccion, string descripcionSeccion, int idEstante)
    {
        IdSeccion = idSeccion;
        DescripcionSeccion = descripcionSeccion;
        IdEstante = idEstante;
    }

    public void UpdateIdSeccion(int newIdSeccion)
    {
        IdSeccion = newIdSeccion;
    }

    public void UpdateDescripcionSeccion(string newDescripcionSeccion)
    {
        DescripcionSeccion = newDescripcionSeccion;
    }
}
