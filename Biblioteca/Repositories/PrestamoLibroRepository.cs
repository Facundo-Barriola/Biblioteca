using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class PrestamoLibroRepository : IPrestamoLibroRepository
    {
        private BibliotecaContext _context;

        public PrestamoLibroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluido con Entity Framework Core.

        /// Incluir a "IdLibroNavigation" y "IdPrestamoNavigation" permite que al obtener un PrestamoLibro, también se lean las referencias a las entidades Libro y Prestamo asociadas.

        public PrestamoLibro GetById(int id)
        {
            return _context.PrestamoLibros
                .Include(pl => pl.IdLibroNavigation)
                .Include(pl => pl.IdPrestamoNavigation)
                .FirstOrDefault(pl => pl.IdPrestamoLibro == id);
        }

        public IEnumerable<PrestamoLibro> GetAll()
        {
            return _context.PrestamoLibros
                .Include(pl => pl.IdLibroNavigation)
                .Include(pl => pl.IdPrestamoNavigation)
                .ToList();
        }

        public void Add(PrestamoLibro prestamoLibro)
        {
            _context.PrestamoLibros.Add(prestamoLibro);
            _context.SaveChanges();
        }

        public void Update(PrestamoLibro prestamoLibro)
        {
            _context.PrestamoLibros.Update(prestamoLibro);
            _context.SaveChanges();
        }

        public void Delete(PrestamoLibro prestamoLibro)
        {
            _context.PrestamoLibros.Remove(prestamoLibro);
            _context.SaveChanges();
        }
    }
}
