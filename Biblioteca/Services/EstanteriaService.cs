using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class EstanteriaService : IEstanteriaService
    {
        private readonly IEstanteriaRepository _estanteriaRepository;

        public EstanteriaService(IEstanteriaRepository estanteriaRepository)
        {
            _estanteriaRepository = estanteriaRepository;
        }

        public IEnumerable<Estanteria> GetAllEstanterias()
        {
            return _estanteriaRepository.GetAll();
        }

        public Estanteria GetEstanteriaById(int id)
        {
            return _estanteriaRepository.GetById(id);
        }

        public void AddEstanteria(Estanteria estanteria)
        {
            _estanteriaRepository.Add(estanteria);
        }

        public void UpdateEstanteria(Estanteria estanteria)
        {
            _estanteriaRepository.Update(estanteria);
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

    public interface IEstanteriaService
    {
        IEnumerable<Estanteria> GetAllEstanterias();
        Estanteria GetEstanteriaById(int id);
        void AddEstanteria(Estanteria estanteria);
        void UpdateEstanteria(Estanteria estanteria);
        void DeleteEstanteria(int id);
    }
}
