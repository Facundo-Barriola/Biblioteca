using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class EstanteService
    {
        private IEstanteRepository _estanteRepository;

        public EstanteService(IEstanteRepository estanteRepository)
        {
            _estanteRepository = estanteRepository;
        }

        public List<Estante> GetAllEstantes()
        {
            return _estanteRepository.GetAll();
        }

        public Estante GetEstanteById(int id)
        {
            return _estanteRepository.GetById(id);
        }

        public void AddEstante(int idEstante, string descripcionEstante, int idEstanteria)
        {
            Estante estante = new Estante(idEstante, descripcionEstante, idEstanteria);
            _estanteRepository.Add(estante);
        }

        public void UpdateEstante(int idEstante, string descripcionEstante, int idEstanteria)
        {
            Estante estante = new Estante(idEstante, descripcionEstante, idEstanteria);
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
}
