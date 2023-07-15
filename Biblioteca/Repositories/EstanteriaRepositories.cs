using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class EstanteriaRepository : IEstanteriaRepository
    {
        private readonly BibliotecaContext _context;

        public EstanteriaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        ///GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// GetById y GetAll con sintáxis similar a SQL implementado con LINQ
        /// SaveChanges es un método que no se declara en BibliotecaContext porque ya viene incluído con Entity Framework Core.

        ///Incluir a "Estantes" permite que al obtener una estantería, también se lean los estantes asociados.
        public Estanteria GetById(int id)
        {
            return _context.Estanterias
                .Include(e => e.Estantes)
                .FirstOrDefault(e => e.IdEstanteria == id);
        }

        public IEnumerable<Estanteria> GetAll()
        {
            return _context.Estanterias
                .Include(e => e.Estantes)
                .ToList();
        }

        public void Add(Estanteria estanteria)
        {
            _context.Estanterias.Add(estanteria);
            _context.SaveChanges();
        }

        public void Update(Estanteria estanteria)
        {
            _context.Estanterias.Update(estanteria);
            _context.SaveChanges();
        }

        public void Delete(Estanteria estanteria)
        {
            _context.Estanterias.Remove(estanteria);
            _context.SaveChanges();
        }
    }

    public interface IEstanteriaRepository
    {
        Estanteria GetById(int id);
        IEnumerable<Estanteria> GetAll();
        void Add(Estanteria estanteria);
        void Update(Estanteria estanteria);
        void Delete(Estanteria estanteria);
    }
}
