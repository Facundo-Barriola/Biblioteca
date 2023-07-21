using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IPrestamoLibroRepository
    {
        List<PrestamoLibro> GetAll();
        PrestamoLibro Insertar(PrestamoLibro PrestamoLibro);
        void Editar(PrestamoLibro PrestamoLibro);
        void Borrar(int prestamoLibroId);
        PrestamoLibro BuscarPorId(int prestamoLibroId);
    }
}