using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IEstanteRepository
    {
        List<Estante> GetAll();
        Estante Insertar(Estante Estante);
        void Editar(Estante Estante);
        void Borrar(int estanteId);
        Estante BuscarPorId(int estanteId);
    }
}