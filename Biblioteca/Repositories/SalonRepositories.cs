using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private readonly BibliotecaContext _context;

        public SalonRepository(BibliotecaContext context)
        {
            _context = context;
        }

        ///GetById y GetAll con sintáxis similar a SQL implementado con LINQ <summary>
        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluído con Entity Framework Core.

        public Salon GetById(int id)
        {
            return _context.Salons
                .FirstOrDefault(s => s.IdSalon == id);
        }

        public IEnumerable<Salon> GetAll()
        {
            return _context.Salons.ToList();
        }

        public void Add(Salon salon)
        {
            _context.Salons.Add(salon);
            _context.SaveChanges();
        }

        public void Update(Salon salon)
        {
            _context.Salons.Update(salon);
            _context.SaveChanges();
        }

        public void Delete(Salon salon)
        {
            _context.Salons.Remove(salon);
            _context.SaveChanges();
        }
    }

    public interface ISalonRepository
    {
        Salon GetById(int id);
        IEnumerable<Salon> GetAll();
        void Add(Salon salon);
        void Update(Salon salon);
        void Delete(Salon salon);
    }
}