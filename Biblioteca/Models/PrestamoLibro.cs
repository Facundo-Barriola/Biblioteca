﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class PrestamoLibro
{
    public int IdPrestamoLibro { get; set; }

    public int IdPrestamo { get; set; }

    public int IdLibro { get; set; }

    public Libro IdLibroNavigation { get; set; } = null!;

    public Prestamo IdPrestamoNavigation { get; set; } = null!;

    public PrestamoLibro(int idPrestamoLibro, int idPrestamo, int idLibro)
    {
        IdPrestamoLibro = idPrestamoLibro;
        IdPrestamo = idPrestamo;
        IdLibro = idLibro;
    }

    public void UpdateIdPrestamoLibro(int newIdPrestamoLibro)
    {
        IdPrestamoLibro = newIdPrestamoLibro;
    }

    public void UpdateIdPrestamo(int newIdPrestamo)
    {
        IdPrestamo = newIdPrestamo;
    }

    public void UpdateIdLibro(int newIdLibro)
    {
        IdLibro = newIdLibro;
    }

}
