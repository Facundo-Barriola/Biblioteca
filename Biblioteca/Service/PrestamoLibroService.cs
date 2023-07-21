using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class PrestamoLibroService
    {
        private IPrestamoLibroRepository _prestamoLibroRepository;

        public PrestamoLibroService(IPrestamoLibroRepository prestamoLibroRepository)
        {
            _prestamoLibroRepository = prestamoLibroRepository;
        }

        public List<PrestamoLibro> GetAllPrestamoLibros()
        {
            return _prestamoLibroRepository.GetAll();
        }

        public PrestamoLibro BuscarPrestamoLibroPorId(int id)
        {
            return _prestamoLibroRepository.BuscarPorId(id);
        }

        public PrestamoLibro InsertarPrestamoLibro(int idPrestamoLibro, int IdPrestamo, int idLibro)
        {
            PrestamoLibro prestamoLibro = new PrestamoLibro(idPrestamoLibro, IdPrestamo, idLibro);
            return _prestamoLibroRepository.Insertar(prestamoLibro);
        }

        public void EditarPrestamoLibro(PrestamoLibro prestamoLibro)
        {
            _prestamoLibroRepository.Editar(prestamoLibro);
        }

        public void BorrarPrestamoLibro(int idPrestamoLibro)
        {
            var prestamoLibro = _prestamoLibroRepository.BuscarPorId(idPrestamoLibro);
            if (prestamoLibro != null)
            {
                _prestamoLibroRepository.Borrar(idPrestamoLibro);
            }
        }
    }
}