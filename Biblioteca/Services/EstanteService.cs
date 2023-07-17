using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class EstanteService : IEstanteService
    {
        private readonly IEstanteRepository _estanteRepository;

        public EstanteService(IEstanteRepository estanteRepository)
        {
            _estanteRepository = estanteRepository;
        }

        public IEnumerable<Estante> GetAllEstantes()
        {
            return _estanteRepository.GetAll();
        }

        public Estante GetEstanteById(int id)
        {
            return _estanteRepository.GetById(id);
        }

        public void AddEstante(Estante estante)
        {
            _estanteRepository.Add(estante);
        }

        public void UpdateEstante(Estante estante)
        {
            _estanteRepository.Update(estante);
        }

        public void DeleteEstante(int id)
        {
            var estante = _estanteRepository.GetById(id);
            if (estante != null)
            {
                _estanteRepository.Delete(estante);
            }
        }
    }

    public interface IEstanteService
    {
        IEnumerable<Estante> GetAllEstantes();
        Estante GetEstanteById(int id);
        void AddEstante(Estante estante);
        void UpdateEstante(Estante estante);
        void DeleteEstante(int id);
    }
}
