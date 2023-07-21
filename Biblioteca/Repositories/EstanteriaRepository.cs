using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class EstanteriaRepository : IEstanteriaRepository
    {
        private BibliotecaContext _context;

        public EstanteriaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public Models.Estanteria Insertar(Models.Estanteria estanteria)
        {
            var modelEstanteria = new Models.Estanteria
            {
                IdEstanteria = estanteria.IdEstanteria,
                DescripcionEstanteria = estanteria.DescripcionEstanteria,
                IdSalon = estanteria.IdSalon
            };

            _context.Estanterias.Add(modelEstanteria);
            _context.SaveChanges();
            return estanteria;
        }

        public Models.Estanteria BuscarPorId(int id)
        {
            var dbEstanteria = _context.Estanterias.FirstOrDefault(e => e.IdEstanteria == id);
            if (dbEstanteria != null)
            {
                var estanteria = new Models.Estanteria
                (
                    dbEstanteria.IdEstanteria,
                    dbEstanteria.DescripcionEstanteria,
                    dbEstanteria.IdSalon
                );
                return estanteria;
            }
            return null;
        }

        public List<Models.Estanteria> GetAll()
        {
            var dbEstanterias = _context.Estanterias.ToList();
            var modelEstanterias = new List<Models.Estanteria>();
            foreach (var dbEstanteria in dbEstanterias)
            {
                modelEstanterias.Add(new Models.Estanteria
                {
                    dbEstanteria.IdEstanteria,
                    dbEstanteria.DescripcionEstanteria,
                    dbEstanteria.IdSalon
                });
            }
            return modelEstanterias;
        }

        public void Editar(Models.Estanteria estanteria)
        {
            var dbEstanteria = _context.Estanterias.FirstOrDefault(e => e.IdEstanteria == estanteria.IdEstanteria);
            if (dbEstanteria != null)
            {
                dbEstanteria.DescripcionEstanteria = estanteria.DescripcionEstanteria;
                dbEstanteria.IdSalon = estanteria.IdSalon;
                _context.SaveChanges();
            }
        }

        public void Borrar(int estanteriaId)
        {
            Estanteria estanteria = _context.Estanterias.Find(estanteriaId);
            if (estanteria != null)
            {
                _context.Estanterias.Remove(estanteria);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró la estanteria con el ID especificado");
            }
        }

    }
}
