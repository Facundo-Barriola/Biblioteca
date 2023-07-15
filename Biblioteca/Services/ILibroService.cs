using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ILibroService
    {
        IEnumerable<Libro> GetAllLibros();

        void CreateLibro(Libro libro);
        void DeleteLibro(int idLibro);
    }
}
