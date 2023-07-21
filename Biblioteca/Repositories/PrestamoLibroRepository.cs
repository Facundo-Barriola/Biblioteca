using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public Models.PrestamoLibro Insertar(Models.PrestamoLibro prestamoLibro)
        {
            var modelPrestamoLibro = new Models.PrestamoLibro
            {
                IdPrestamoLibro = prestamoLibro.IdPrestamoLibro,
                IdPrestamo = prestamoLibro.IdPrestamo,
                IdLibro = prestamoLibro.IdLibro
            };

            _context.PrestamoLibros.Add(modelPrestamoLibro);
            _context.SaveChanges();
            return prestamoLibro;
        }

        public Models.PrestamoLibro BuscarPorId(int id)
        {
            var dbPrestamoLibro = _context.PrestamoLibros.FirstOrDefault(e => e.IdPrestamoLibro == id);
            if (dbPrestamoLibro != null)
            {
                var prestamoLibro = new Models.PrestamoLibro
                (
                    dbPrestamoLibro.IdPrestamoLibro,
                    dbPrestamoLibro.IdPrestamo,
                    dbPrestamoLibro.IdLibro
                );
                return prestamoLibro;
            }
            return null;
        }

        public List<Models.PrestamoLibro> GetAll()
        {
            var dbPrestamoLibros = _context.PrestamoLibros.ToList();
            var modelPrestamoLibros = new List<Models.PrestamoLibro>();
            foreach (var dbPrestamoLibro in dbPrestamoLibros)
            {
                modelPrestamoLibros.Add(new Models.PrestamoLibro
                {
                    dbPrestamoLibro.IdPrestamoLibro,
                    dbPrestamoLibro.IdPrestamo,
                    dbPrestamoLibro.IdLibro
                });
            }
            return modelPrestamoLibros;
        }

        public void Editar(Models.PrestamoLibro prestamoLibro)
        {
            var dbPrestamoLibro = _context.PrestamoLibros.FirstOrDefault(e => e.IdPrestamoLibro == prestamoLibro.IdPrestamoLibro);
            if (dbPrestamoLibro != null)
            {
                dbPrestamoLibro.IdPrestamo = prestamoLibro.IdPrestamo;
                dbPrestamoLibro.IdLibro = prestamoLibro.IdLibro;
                _context.SaveChanges();
            }
        }

        public void Borrar(int prestamoLibroId)
        {
            PrestamoLibro prestamoLibro = _context.PrestamoLibros.Find(prestamoLibroId);
            if (prestamoLibro != null)
            {
                _context.PrestamoLibros.Remove(prestamoLibro);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró el prestamoLibro con el ID especificado");
            }
        }

    }
}