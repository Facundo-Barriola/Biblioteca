using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class EstanteRepository : IEstanteRepository
    {
        private BibliotecaContext _context;

        public EstanteRepository(BibliotecaContext context)
        {
            _context = context;
        }

        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluído con Entity Framework Core

        ///Incluir a "Seccions" permite que al obtener un estante, también se lean las secciones asociadas
        public Estante GetById(int id)
        {
            return _context.Estantes
                .Include(e => e.Seccions)
                .FirstOrDefault(e => e.IdEstante == id);
        }

        public IEnumerable<Estante> GetAll()
        {
            return _context.Estantes
                .Include(e => e.Seccions)
                .ToList();
        }

        public void Add(Estante estante)
        {
            _context.Estantes.Add(estante);
            _context.SaveChanges();
        }

        public void Update(Estante estante)
        {
            _context.Estantes.Update(estante);
            _context.SaveChanges();
        }

        public void Delete(Estante estante)
        {
            _context.Estantes.Remove(estante);
            _context.SaveChanges();
        }
    }
}