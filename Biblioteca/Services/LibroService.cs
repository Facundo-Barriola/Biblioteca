using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services
{
    public class LibroService : ILibroService
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

        public void AniadirLibro(Libro libro) 
        {
            _libroRepository.Aniadir(libro);
        }

        public void BorrarLibro(int idLibro) 
        {
            _libroRepository.Borrar(idLibro);
        }
    }
}
