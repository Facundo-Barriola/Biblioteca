using BibliotecaDB;
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
        public Models.Libro Insertar(Models.Libro libro)
        {
            var modelLibro = new Models.Libro(libro.IdLibro, libro.Titulo, libro.Sinopsis, libro.PuntajeCritica,
                libro.Estado, libro.Disponibilidad, libro.IdSeccion);
            var dbLibro = new BibliotecaDB.Libro
            {
                IdLibro = libro.IdLibro,
                Titulo = libro.Titulo,
                Sinopsis = libro.Sinopsis,
                PuntajeCritica = libro.PuntajeCritica,
                Estado = libro.Estado,
                Disponibilidad = libro.Disponibilidad,
                IdSeccion = libro.IdSeccion
            };
            modelLibro.EditarId(dbLibro.IdLibro);
            _bibliotecaContext.Libros.Add(dbLibro);
            _bibliotecaContext.SaveChanges();
            return libro;
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

        public List<Models.Libro> GetAll()
        {
            var dbLibros = _bibliotecaContext.Libros.ToList();
            var modelLibros = new List<Models.Libro>();
            foreach( var dbLibro in dbLibros) 
            {
                modelLibros.Add(new Models.Libro(
                    dbLibro.IdLibro,
                    dbLibro.Titulo,
                    dbLibro.Sinopsis,
                    dbLibro.PuntajeCritica,
                    dbLibro.Estado,
                    dbLibro.Disponibilidad,
                    dbLibro.IdSeccion
                    ));
            }
            return modelLibros;
        }

        public List<Models.Libro> GetLibroBySeccion(int id_seccion)
        {
            var dbLibros = _bibliotecaContext.Libros.ToList();
            var LibrosEnSeccion = new List<Models.Libro>();

            foreach (var dbLibro in dbLibros)
            { 
                if(dbLibro.IdSeccion == id_seccion)
                    LibrosEnSeccion.Add(new Models.Libro(
                    dbLibro.IdLibro,
                    dbLibro.Titulo,
                    dbLibro.Sinopsis,
                    dbLibro.PuntajeCritica,
                    dbLibro.Estado,
                    dbLibro.Disponibilidad,
                    dbLibro.IdSeccion
                    )
                 );
            }
            return LibrosEnSeccion;
        } 

        public void Editar(Models.Libro libro)
        {
            var dbLibro = _bibliotecaContext.Libros.FirstOrDefault(l => l.IdLibro == libro.IdLibro);
            if (dbLibro != null) 
            {
                dbLibro.Titulo = libro.Titulo;
                dbLibro.Sinopsis = libro.Sinopsis;
                dbLibro.PuntajeCritica = libro.PuntajeCritica;
                dbLibro.Estado = libro.Estado;
                dbLibro.Disponibilidad = libro.Disponibilidad;
                dbLibro.IdSeccion = libro.IdSeccion;

                _bibliotecaContext.SaveChanges();
            }          
        }

        public Models.Libro BuscarPorId(int idLibro) 
        {
            var dbLibro = _bibliotecaContext.Libros.FirstOrDefault(l => l.IdLibro == idLibro);
            if (dbLibro != null) 
            {
                var libro = new Models.Libro
                (
                    dbLibro.IdLibro,
                    dbLibro.Titulo,
                    dbLibro.Sinopsis,
                    dbLibro.PuntajeCritica,
                    dbLibro.Estado,
                    dbLibro.Disponibilidad,
                    dbLibro.IdSeccion
                );
                return libro;
            }
            return null;
        }
    }
}
