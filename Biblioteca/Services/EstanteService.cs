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

        public Estante BuscarEstantePorId(int id)
        {
            return _estanteRepository.BuscarPorId(id);
        }

        public Estante InsertarEstante(int idEstante, string descripcionEstante, int idEstanteria)
        {
            Estante estante = new Estante(idEstante, descripcionEstante, idEstanteria);
            return _estanteRepository.Insertar(estante);
        }

        public void EditarEstante(Estante estante)
        {
            _estanteRepository.Editar(estante);
        }

        public void BorrarEstante(int idEstante)
        {
            var estante = _estanteRepository.BuscarPorId(idEstante);
            if (estante != null)
            {
                _estanteRepository.Borrar(idEstante);
            }
        }
    }
}