﻿using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private BibliotecaContext _bibliotecaContext;

        public LibroRepository(BibliotecaContext context)
        {
            _bibliotecaContext = context;
        }
        public void Create(Libro libro)
        {
            _bibliotecaContext.Libros.Add(libro);
        }

        public void Delete(int libroId)
        {
            Libro libro = _bibliotecaContext.Libros.Find(libroId);
            if (libro != null) 
            {
                _bibliotecaContext.Libros.Remove(libro);
            }
        }

        public IEnumerable<Libro> GetAll()
        {
            return _bibliotecaContext.Libros.ToList();
        }

        public IEnumerable<Libro> GetLibroBySeccion(int id_seccion)
        {
            Seccion seccion = _bibliotecaContext.Seccions.Find(id_seccion);
            if (seccion != null) 
            {
                // Debe retornat una lista de libros según la sección que se pase por parámetro
                return _bibliotecaContext.Libros.ToList();//.Where(id_seccion); 
            }
            return Enumerable.Empty<Libro>();
        }

        public void Update(Libro libro)
        {
            _bibliotecaContext.Entry(libro).State = EntityState.Modified;
        }
    }
}
