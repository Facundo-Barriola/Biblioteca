using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class SalonService
    {
        private ISalonRepository _salonRepository;

        public SalonService(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        public List<Salon> GetAllSalones()
        {
            return _salonRepository.GetAll();
        }

        public Salon BuscarSalonPorId(int id)
        {
            return _salonRepository.BuscarPorId(id);
        }

        public Salon InsertarSalon(int idSalon, string descripcionSalon)
        {
            Salon salon = new Salon(idSalon, descripcionSalon);
            return _salonRepository.Insertar(salon);
        }

        public void EditarSalon(Salon salon)
        {
            _salonRepository.Editar(salon);
        }

        public void BorrarSalon(int id)
        {
            var salon = _salonRepository.BuscarPorId(id);
            if (salon != null)
            {
                _salonRepository.Borrar(id);
            }
        }

    }
}