using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _salonRepository;

        public SalonService(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        public IEnumerable<Salon> GetAllSalones()
        {
            return _salonRepository.GetAll();
        }

        public Salon GetSalonById(int id)
        {
            return _salonRepository.GetById(id);
        }

        public void AddSalon(Salon salon)
        {
            _salonRepository.Add(salon);
        }

        public void UpdateSalon(Salon salon)
        {
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

    public interface ISalonService
    {
        IEnumerable<Salon> GetAllSalones();
        Salon GetSalonById(int id);
        void AddSalon(Salon salon);
        void UpdateSalon(Salon salon);
        void DeleteSalon(int id);
    }
}