using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class SeccionService : ISeccionService
    {
        private readonly ISeccionRepository _seccionRepository;

        public SeccionService(ISeccionRepository seccionRepository)
        {
            _seccionRepository = seccionRepository;
        }

        public IEnumerable<Seccion> GetAllSecciones()
        {
            return _seccionRepository.GetAll();
        }

        public Seccion GetSeccionById(int id)
        {
            return _seccionRepository.GetById(id);
        }

        public void AddSeccion(Seccion seccion)
        {
            _seccionRepository.Add(seccion);
        }

        public void UpdateSeccion(Seccion seccion)
        {
            _seccionRepository.Update(seccion);
        }

        public void DeleteSeccion(int id)
        {
            var seccion = _seccionRepository.GetById(id);
            if (seccion != null)
            {
                _seccionRepository.Delete(seccion);
            }
        }
    }

    public interface ISeccionService
    {
        IEnumerable<Seccion> GetAllSecciones();
        Seccion GetSeccionById(int id);
        void AddSeccion(Seccion seccion);
        void UpdateSeccion(Seccion seccion);
        void DeleteSeccion(int id);
    }
}
