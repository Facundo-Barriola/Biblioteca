using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface ISalonRepository
    {
        List<Salon> GetAll();
        Salon Insertar(Salon salon);
        void Editar(Salon salon);
        void Borrar(int salonId);
        Salon BuscarPorId(int idSalon);
    }
}