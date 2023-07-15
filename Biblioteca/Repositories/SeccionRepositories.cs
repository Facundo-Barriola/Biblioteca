using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class SeccionRepository : ISeccionRepository
    {
        private readonly BibliotecaContext _context;

        public SeccionRepository(BibliotecaContext context)
        {
            _context = context;
        }

        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluído con Entity Framework Core.

        ///Incluir a "Libros" permite que al obtener una Sección, también se lean los libros asociados.
        
        public Seccion GetById(int id)
        {
            return _context.Seccions
                .Include(s => s.Libros)
                .FirstOrDefault(s => s.IdSeccion == id);
        }

        public IEnumerable<Seccion> GetAll()
        {
            return _context.Seccions
                .Include(s => s.Libros)
                .ToList();
        }

        public void Add(Seccion seccion)
        {
            _context.Seccions.Add(seccion);
            _context.SaveChanges();
        }

        public void Update(Seccion seccion)
        {
            _context.Seccions.Update(seccion);
            _context.SaveChanges();
        }

        public void Delete(Seccion seccion)
        {
            _context.Seccions.Remove(seccion);
            _context.SaveChanges();
        }
    }

    public interface ISeccionRepository
    {
        Seccion GetById(int id);
        IEnumerable<Seccion> GetAll();
        void Add(Seccion seccion);
        void Update(Seccion seccion);
        void Delete(Seccion seccion);
    }
}
