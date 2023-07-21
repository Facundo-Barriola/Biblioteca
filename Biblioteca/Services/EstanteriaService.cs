using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class EstanteriaService
    {
        private IEstanteriaRepository _estanteriaRepository;

        public EstanteriaService(IEstanteriaRepository estanteriaRepository)
        {
            _estanteriaRepository = estanteriaRepository;
        }

        public List<Estanteria> GetAllEstanterias()
        {
            return _estanteriaRepository.GetAll();
        }

        public Estanteria BuscarEstanteriaPorId(int id)
        {
            return _estanteriaRepository.BuscarPorId(id);
        }

        public Estanteria InsertarEstanteria(int idEstanteria, string descripcionEstanteria, int idSalon)
        {
            Estanteria estanteria = new Estanteria(idEstanteria, descripcionEstanteria, idSalon);
            return _estanteriaRepository.Insertar(estanteria);
        }

        public void EditarEstanteria(Estanteria estanteria)
        {
            _estanteriaRepository.Editar(estanteria);
        }

        public void BorrarEstanteria(int idEstanteria)
        {
            var estanteria = _estanteriaRepository.BuscarPorId(idEstanteria);
            if (estanteria != null)
            {
                _estanteriaRepository.Borrar(idEstanteria);
            }
        }
    }
}
