using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Dni { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool Tipo { get; set; }

    private ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public Usuario(int idUsuario, string dni, string nombre, string apellido, DateTime fechaNacimiento,
        string telefono, string mail, string contrasena, bool tipo) 
    {
        IdUsuario = idUsuario;
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Telefono = telefono;
        Mail = mail;
        Contrasena = contrasena;
        Tipo = tipo;
    }

    public void EditarId(int idUsuario)
    {
        IdUsuario = idUsuario;
    }
}
