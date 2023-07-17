using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class SeccionService
    {
        private ISeccionRepository _seccionRepository;

        public SeccionService(ISeccionRepository seccionRepository)
        {
            _seccionRepository = seccionRepository;
        }

        public List<Seccion> GetAllSecciones()
        {
            return _seccionRepository.GetAll();
        }

        public Seccion GetSeccionById(int id)
        {
            return _seccionRepository.GetById(id);
        }

        public void AddSeccion(int idSeccion, string descripcionSeccion, int idEstante)
        {
            Seccion seccion = new Seccion(idSeccion, descripcionSeccion, idEstante);
            _seccionRepository.Add(seccion);
        }

        public void UpdateSeccion(int idSeccion, string descripcionSeccion, int idEstante)
        {
            Seccion seccion = new Seccion(idSeccion, descripcionSeccion, idEstante);
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