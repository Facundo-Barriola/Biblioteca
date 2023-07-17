using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface ILibroRepository
    {
        List<Libro> GetAll();
        void Aniadir(Libro libro);
        void Editar(Libro libro);
        void Borrar(int id);
        List<Libro> GetLibroBySeccion(int id_seccion);
    }
}
