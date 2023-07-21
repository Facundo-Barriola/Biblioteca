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

        public Seccion BuscarSeccionPorId(int id)
        {
            return _seccionRepository.BuscarPorId(id);
        }

        public Seccion InsertarSeccion(int idSeccion, string descripcionSeccion, int idEstante)
        {
            Seccion seccion = new Seccion(idSeccion, descripcionSeccion, idEstante);
            return _seccionRepository.Insertar(seccion);
        }

        public void EditarSeccion(Seccion seccion)
        {
            _seccionRepository.Editar(seccion);
        }

        public void BorrarSeccion(int idSeccion)
        {
            var seccion = _seccionRepository.BuscarPorId(idSeccion);
            if (seccion != null)
            {
                _seccionRepository.Borrar(idSeccion);
            }
        }
    }
}