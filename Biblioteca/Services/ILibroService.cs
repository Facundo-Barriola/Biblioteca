using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ILibroService
    {
        IEnumerable<Libro> GetAllLibros();
    }
}
