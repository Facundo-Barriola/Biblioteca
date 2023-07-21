using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IPrestamoLibroRepository
    {
        PrestamoLibro<PrestamoLibro> GetAll();
        PrestamoLibro Insertar(PrestamoLibro PrestamoLibro);
        void Editar(PrestamoLibro PrestamoLibro);
        void Borrar(int prestamoLibroId);
        PrestamoLibro BuscarPorId(int prestamoLibroId);
    }
}