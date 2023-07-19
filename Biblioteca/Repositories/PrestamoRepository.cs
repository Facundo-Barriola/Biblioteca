using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private BibliotecaContext _context;

        public PrestamoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluido con Entity Framework Core.

        /// Incluir a "PrestamoLibros" permite que al obtener un Prestamo, también se lean los libros asociados al prestamo.

        public Prestamo GetById(int id)
        {
            return _context.Prestamos
                .Include(p => p.PrestamoLibros)
                .FirstOrDefault(p => p.IdPrestamo == id);
        }

        public IEnumerable<Prestamo> GetAll()
        {
            return _context.Prestamos
                .Include(p => p.PrestamoLibros)
                .ToList();
        }

        public void Add(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
        }

        public void Update(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            _context.SaveChanges();
        }

        public void Delete(Prestamo prestamo)
        {
            _context.Prestamos.Remove(prestamo);
            _context.SaveChanges();
        }
    }
}
