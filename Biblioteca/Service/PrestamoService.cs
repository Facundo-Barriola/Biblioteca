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

        public Prestamo BuscarPrestamoPorId(int id)
        {
            return _prestamoRepository.BuscarPorId(id);
        }

        public Prestamo InsertarPrestamo(int idPrestamo, DateTime? fechaExtraccion, DateTime fechaDevolucion, DateTime fechaPactada, bool? estadoPrestamo, string idUsuario)
        {
            Prestamo prestamo = new Prestamo(idPrestamo, fechaExtraccion, fechaDevolucion, fechaPactada, estadoPrestamo, idUsuario);
            return _prestamoRepository.Insertar(prestamo);
        }

        public void EditarPrestamo(Prestamo prestamo)
        {
            _prestamoRepository.Editar(prestamo);
        }

        public void BorrarPrestamo(int idPrestamo)
        {
            var prestamo = _prestamoRepository.BuscarPorId(idPrestamo);
            if (prestamo != null)
            {
                _prestamoRepository.Borrar(idPrestamo);
            }
        }
    }
}