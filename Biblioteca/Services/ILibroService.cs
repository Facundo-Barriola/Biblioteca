using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ILibroService
    {
        List<Libro> GetAllLibros();

        Libro InsertarLibro(Libro libro);
        void BorrarLibro(int idLibro);
    }
}
