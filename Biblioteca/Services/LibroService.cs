using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services
{
    public class LibroService 
    {
        private ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository) 
        {
            _libroRepository = libroRepository;
        }
        public List<Libro> GetAllLibros()
        {
            return _libroRepository.GetAll();
        }

        public Libro InsertarLibro(int id, string titulo, string sinopsis, int puntajeCritica,
            int estado, bool disponibilidad, int idSeccion) 
        {   
            Libro libro = new Libro(id, titulo, sinopsis, puntajeCritica,
                estado, disponibilidad, idSeccion);
            return _libroRepository.Insertar(libro);
        }

        public void BorrarLibro(int idLibro) 
        {
            _libroRepository.Borrar(idLibro);
        }
    }
}
