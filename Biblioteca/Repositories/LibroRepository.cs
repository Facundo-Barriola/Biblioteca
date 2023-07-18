using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private BibliotecaContext _bibliotecaContext;

        public LibroRepository(BibliotecaContext context)
        {
            _bibliotecaContext = context;
        }
        public void Aniadir(Libro libro)
        {
            _bibliotecaContext.Libros.Add(libro);
        }

        public void Borrar(int libroId)
        {
            Libro libro = _bibliotecaContext.Libros.Find(libroId);
            if (libro != null)
            {
                _bibliotecaContext.Libros.Remove(libro);
                _bibliotecaContext.SaveChanges();
            }
            else 
            {
                throw new Exception("No se encontró el libro con el ID especificado");
            }
        }

        public List<Libro> GetAll()
        {
            return _bibliotecaContext.Libros.ToList();
        }

         public List<Libro> GetLibroBySeccion(int id_seccion)
        {
            Seccion seccion = _bibliotecaContext.Seccions.Find(id_seccion);
            if (seccion != null) 
            {
                return _bibliotecaContext.Libros.Where(l => l.IdSeccion == id_seccion).ToList();
            }
            return new List<Libro>();
        } 

        public void Editar(Libro libro)
        {
            _bibliotecaContext.Entry(libro).State = EntityState.Modified;
        }
    }
}
