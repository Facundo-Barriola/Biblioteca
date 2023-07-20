using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private BibliotecaContext _context;

        public SalonRepository(BibliotecaContext context)
        {
            _context = context;
        }

        ///GetById y GetAll con sintáxis similar a SQL implementado con LINQ <summary>
        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluído con Entity Framework Core.

        public Models.Salon GetById(int id)
        {
            var dbSalon = _context.Salones.FirstOrDefault(s => s.IdSalon == id);
            if (dbSalon != null) 
            {
                var salon = new Models.Salon(
                    dbSalon.IdSalon,
                    dbSalon.DescripcionSalon
                    );
                return salon;
            }
            return null;
        }

        public List<Models.Salon> GetAll()
        {
            var modelSalones = new List<Models.Salon>();
            var dbSalones = _context.Salones.ToList();
            foreach (var dbSalon in dbSalones) 
            {
                modelSalones.Add(new Models.Salon
                    (
                        dbSalon.IdSalon,
                        dbSalon.DescripcionSalon
                    )); 
            }
            return modelSalones;
        }

        public Models.Salon Add(Models.Salon salon)
        {
            var modelSalon = new Models.Salon(salon.IdSalon, salon.DescripcionSalon);
            var dbSalon = new BibliotecaDB.Salon
            { 
                IdSalon = salon.IdSalon,
                DescripcionSalon = salon.DescripcionSalon
            };
            modelSalon.UpdateIdSalon(dbSalon.IdSalon);
            _context.Salones.Add(dbSalon);
            _context.SaveChanges();
            return salon;
        }

        public Models.Salon Update(Models.Salon salon)
        {
            var dbSalon = _context.Salones.FirstOrDefault(s => s.IdSalon == salon.IdSalon);
            if (dbSalon != null) 
            {
                dbSalon.IdSalon = salon.IdSalon;
                dbSalon.DescripcionSalon = salon.DescripcionSalon;

                _context.SaveChanges();
                return salon;
            }
            return null;
        }

        public void Delete(Models.Salon salon)
        {
            var dbSalon = _context.Salones.FirstOrDefault(s => s.IdSalon == salon.IdSalon);
            if (dbSalon != null) 
            {
                _context.Salones.Remove(dbSalon); 
                _context.SaveChanges();
            }
        }
    }
}