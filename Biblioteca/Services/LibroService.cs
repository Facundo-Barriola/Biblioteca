using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services
{
    public class LibroService : ILibroService
    {
        private LibroRepository _libroRespository;

        public LibroService(LibroRepository libroRepository) 
        {
            _libroRespository = libroRepository;
        }
        public IEnumerable<Libro> GetAllLibros()
        {
            return _libroRespository.GetAll();
        }

        public void CreateLibro(Libro libro) 
        {
            _libroRespository.Create(libro);
        }

        public void DeleteLibro(int idLibro) 
        {
            _libroRespository.Delete(idLibro);
        }
    }
}
