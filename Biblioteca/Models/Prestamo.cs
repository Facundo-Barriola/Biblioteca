using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Prestamo
{
    public int IdPrestamo { get; set; }

    public DateTime? FechaExtraccion { get; set; }

    public DateTime FechaDevolucion { get; set; }

    public DateTime FechaPactada { get; set; }

    public bool? EstadoPrestamo { get; set; }

    public string IdUsuario { get; set; } = null!;

    private Usuario IdUsuarioNavigation { get; set; } = null!;

    private ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();

    public Prestamo(int idPrestamo, DateTime? fechaExtraccion, DateTime fechaDevolucion, DateTime fechaPactada, bool? estadoPrestamo, string idUsuario)
    {
        IdPrestamo = idPrestamo;
        FechaExtraccion = fechaExtraccion;
        FechaDevolucion = fechaDevolucion;
        FechaPactada = fechaPactada;
        EstadoPrestamo = estadoPrestamo;
        IdUsuario = idUsuario;
    }

    public void UpdateIdPrestamo(int newIdPrestamo)
    {
        IdPrestamo = newIdPrestamo;
    }

    public void UpdateFechaExtraccion(DateTime? newFechaExtraccion)
    {
        FechaExtraccion = newFechaExtraccion;
    }

    public void UpdateFechaDevolucion(DateTime newFechaDevolucion)
    {
        FechaDevolucion = newFechaDevolucion;
    }

    public void UpdateFechaPactada(DateTime newFechaPactada)
    {
        FechaPactada = newFechaPactada;
    }

    public void UpdateEstadoPrestamo(bool? newEstadoPrestamo)
    {
        EstadoPrestamo = newEstadoPrestamo;
    }

    public void UpdateIdUsuario(string newIdUsuario)
    {
        IdUsuario = newIdUsuario;
    }
}
