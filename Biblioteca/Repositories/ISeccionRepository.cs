using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface ISeccionRepository
    {
        List<Seccion> GetAll();
        Seccion Insertar(Seccion Seccion);
        void Editar(Seccion Seccion);
        void Borrar(int seccionId);
        Seccion BuscarPorId(int seccionId);
    }
}