using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IPrestamoRepository
    {
        Prestamo<Prestamo> GetAll();
        Prestamo Insertar(Prestamo Prestamo);
        void Editar(Prestamo Prestamo);
        void Borrar(int prestamoId);
        Prestamo BuscarPorId(int prestamoId);
    }
}