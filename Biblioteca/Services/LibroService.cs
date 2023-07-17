using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services
{
    public class LibroService : ILibroService
    {
        private ILibroRepository _libroRespository;

        public LibroService(ILibroRepository libroRepository) 
        {
            _libroRespository = libroRepository;
        }
        public List<Libro> GetAllLibros()
        {
            return _libroRespository.GetAll();
        }

        public void AniadirLibro(Libro libro) 
        {
            _libroRespository.Aniadir(libro);
        }

        public void BorrarLibro(int idLibro) 
        {
            _libroRespository.Borrar(idLibro);
        }
    }
}
