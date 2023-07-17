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

        public Estanteria GetEstanteriaById(int id)
        {
            return _estanteriaRepository.GetById(id);
        }

        public void AddEstanteria(int idEstanteria, string descripcionEstanteria, int idSalon)
        {
            Estanteria estanteria = new Estanteria(idEstanteria, descripcionEstanteria, idSalon);
            _estanteriaRepository.Add(estanteria);
        }

        public void UpdateEstanteria(int idEstanteria, string descripcionEstanteria, int idSalon)
        {
            Estanteria estanteria = new Estanteria(idEstanteria, descripcionEstanteria, idSalon);
            _estanteriaRepository.Add(estanteria);
        }

        public void DeleteEstanteria(int id)
        {
            var estanteria = _estanteriaRepository.GetById(id);
            if (estanteria != null)
            {
                _estanteriaRepository.Delete(estanteria);
            }
        }
    }
}
