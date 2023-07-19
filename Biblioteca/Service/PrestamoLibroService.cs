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

        public List<PrestamoLibro> GetAllPrestamosLibros()
        {
            return _prestamoLibroRepository.GetAll();
        }

        public PrestamoLibro GetPrestamoLibroById(int id)
        {
            return _prestamoLibroRepository.GetById(id);
        }

        public void AddPrestamoLibro(int idPrestamoLibro, int idPrestamo, int idLibro)
        {
            PrestamoLibro prestamoLibro = new PrestamoLibro(idPrestamoLibro, idPrestamo, idLibro);
            _prestamoLibroRepository.Add(prestamoLibro);
        }

        public void UpdatePrestamoLibro(int idPrestamoLibro, int idPrestamo, int idLibro)
        {
            PrestamoLibro prestamoLibro = new PrestamoLibro(idPrestamoLibro, idPrestamo, idLibro);
            _prestamoLibroRepository.Update(prestamoLibro);
        }

        public void DeletePrestamoLibro(int id)
        {
            var prestamoLibro = _prestamoLibroRepository.GetById(id);
            if (prestamoLibro != null)
            {
                _prestamoLibroRepository.Delete(prestamoLibro);
            }
        }
    }
}
