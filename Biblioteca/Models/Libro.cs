using System;
using System.Collections.Generic;
using System.Reflection;

namespace Biblioteca.Models;

public class Libro
{   
    public int IdLibro { get; set; }
    private string _titulo;
    public string Titulo
    {
        get { return _titulo; }
        set
        {
            if (value != null)
            {
                _titulo = value;
            }
            else
            {
                throw new ArgumentNullException(nameof(Titulo), "El título no puede ser nulo.");
            }
        }
    }

    public string Sinopsis { get; set; }

    private int _puntajeCritica;
    public int PuntajeCritica
    {
        get { return _puntajeCritica; }
        set
        {
            if (value >= 0 && value <= 5)
            {
                _puntajeCritica = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(PuntajeCritica), "El puntaje de crítica debe estar entre 0 y 5.");
            }
        }
    }

    public int Estado { get; set; }

    public bool Disponibilidad { get; set; }

    public int IdSeccion { get; set; }
    private Seccion IdSeccionNavigation { get; set; } = null!;
    private ICollection<PrestamoLibro> PrestamoLibros { get; set; } = new List<PrestamoLibro>();

    public Libro(int idLibro, string titulo, string sinopsis, int puntajeCritica,
        int estado, bool disponibilidad, int idSeccion) 
    {
        IdLibro = idLibro;
        Titulo = titulo; 
        Sinopsis = sinopsis;
        PuntajeCritica = puntajeCritica;
        Estado = estado;
        Disponibilidad = disponibilidad;
        IdSeccion = idSeccion;
    }

    public void EditarId(int id) 
    {
        IdLibro = id;
    }
    public void UpdateTitulo(string newTitulo)
    {
        if (newTitulo != null)
        {
            Titulo = newTitulo;
        }
        else
        {
            throw new ArgumentNullException(nameof(newTitulo), "El título no puede ser nulo.");
        }
    }

    public void UpdateSinopsis(string newSinopsis) 
    {
        Sinopsis = newSinopsis;
    }

    public void UpdatePuntaje(int newPuntaje)
    {
        if (newPuntaje >= 0 && newPuntaje <= 5)
        {
            PuntajeCritica = newPuntaje;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(newPuntaje), "El puntaje de crítica debe estar entre 0 y 5.");
        }
    }

    public void UpdateEstado(int newEstado) 
    {
        Estado = newEstado;
    }

    public void UpdateDisponibilidad(int newDisponibilidad) 
    {
        if (newDisponibilidad == 1)
        {
            Disponibilidad = true;
        }
        else { Disponibilidad = false; } 

    }
}
