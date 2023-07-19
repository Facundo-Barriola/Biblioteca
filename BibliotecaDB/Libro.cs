﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BibliotecaDB;

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

    public void UpdateTitulo(string newTitulo) 
    {
        Titulo = newTitulo;
    }
    public void UpdateSinopsis(string newSinopsis) 
    {
        Sinopsis = newSinopsis;
    }
    public void UpdatePuntaje(int newPuntaje) 
    {
        PuntajeCritica = newPuntaje;
    }
    public void UpdateEstado(int newEstado) 
    {
        Estado = newEstado;
    }
    //Consultar si es mejor realizarlo con int o con string
    public void UpdateDisponibilidad(int newDisponibilidad) 
    {
        if (newDisponibilidad == 1)
        {
            Disponibilidad = true;
        }
        else { Disponibilidad = false; } 

    }
}