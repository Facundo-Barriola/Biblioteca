using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ILibroService
    {
        List<Libro> GetAllLibros();

        void AnidirLibro(Libro libro);
        void BorrarLibro(int idLibro);
    }
}
