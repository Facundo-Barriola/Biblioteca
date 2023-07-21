using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public Models.Estante Insertar(Models.Estante estante)
        {
            var modelEstante = new Models.Estante
            {
                IdEstante = estante.IdEstante,
                DescripcionEstante = estante.DescripcionEstante,
                IdEstanteria = estante.IdEstanteria
            };

            _context.Estantes.Add(modelEstante);
            _context.SaveChanges();
            return estante;
        }

        public Models.Estante BuscarPorId(int id)
        {
            var dbEstante = _context.Estantes.FirstOrDefault(e => e.IdEstante == id);
            if (dbEstante != null)
            {
                var estante = new Models.Estante
                (
                    dbEstante.IdEstante,
                    dbEstante.DescripcionEstante,
                    dbEstante.IdEstanteria
                );
                return estante;
            }
            return null;
        }

        public List<Models.Estante> GetAll()
        {
            var dbEstantes = _context.Estantes.ToList();
            var modelEstantes = new List<Models.Estante>();
            foreach (var dbEstante in dbEstantes)
            {
                modelEstantes.Add(new Models.Estante
                {
                    dbEstante.IdEstante,
                    dbEstante.DescripcionEstante,
                    dbEstante.IdEstanteria
                });
            }
            return modelEstantes;
        }

        public void Editar(Models.Estante estante)
        {
            var dbEstante = _context.Estantes.FirstOrDefault(e => e.IdEstante == estante.IdEstante);
            if (dbEstante != null)
            {
                dbEstante.DescripcionEstante = estante.DescripcionEstante;
                dbEstante.IdEstanteria = estante.IdEstanteria;
                _context.SaveChanges();
            }
        }

        public void Borrar(int estanteId)
        {
            Estante estante = _context.Estantes.Find(estanteId);
            if (estante != null)
            {
                _context.Estantes.Remove(estante);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró la estante con el ID especificado");
            }
        }

    }
}