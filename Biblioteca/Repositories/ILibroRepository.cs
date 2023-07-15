using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface ILibroRepository
    {
        IEnumerable<Libro> GetAll();
        void Create(Libro libro);
        void Update(Libro libro);
        void Delete(int id);
        IEnumerable<Libro> GetLibroBySeccion(int id_seccion);
    }
}
