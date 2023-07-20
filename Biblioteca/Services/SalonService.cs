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

        public Salon GetSalonById(int id)
        {
            return _salonRepository.GetById(id);
        }

        public void AddSalon(int idSalon, string descripcionSalon)
        {
            Salon salon = new Salon(idSalon, descripcionSalon);
            _salonRepository.Add(salon);
        }

        public void UpdateSalon(int idSalon, string descripcionSalon)
        {
            Salon salon = new Salon(idSalon, descripcionSalon);
            _salonRepository.Update(salon);
        }

        public void DeleteSalon(int id)
        {
            var salon = _salonRepository.GetById(id);
            if (salon != null)
            {
                _salonRepository.Delete(salon);
            }
        }
    }
}