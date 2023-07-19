using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class PrestamoService
    {
        private IPrestamoRepository _prestamoRepository;

        public PrestamoService(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public List<Prestamo> GetAllPrestamos()
        {
            return _prestamoRepository.GetAll();
        }

        public Prestamo GetPrestamoById(int id)
        {
            return _prestamoRepository.GetById(id);
        }

        public void AddPrestamo(int idPrestamo, DateTime? fechaExtraccion, DateTime fechaDevolucion, DateTime fechaPactada, bool? estadoPrestamo, string idUsuario)
        {
            Prestamo prestamo = new Prestamo(idPrestamo, fechaExtraccion, fechaDevolucion, fechaPactada, estadoPrestamo, idUsuario);
            _prestamoRepository.Add(prestamo);
        }

        public void UpdatePrestamo(int idPrestamo, DateTime? fechaExtraccion, DateTime fechaDevolucion, DateTime fechaPactada, bool? estadoPrestamo, string idUsuario)
        {
            Prestamo prestamo = new Prestamo(idPrestamo, fechaExtraccion, fechaDevolucion, fechaPactada, estadoPrestamo, idUsuario);
            _prestamoRepository.Update(prestamo);
        }

        public void DeletePrestamo(int id)
        {
            var prestamo = _prestamoRepository.GetById(id);
            if (prestamo != null)
            {
                _prestamoRepository.Delete(prestamo);
            }
        }
    }
}
