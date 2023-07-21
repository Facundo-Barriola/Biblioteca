using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class SeccionRepository : ISeccionRepository
    {
        private BibliotecaContext _context;

        public SeccionRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public Models.Seccion Insertar(Models.Seccion seccion)
        {
            var modelSeccion = new Models.Seccion
            {
                IdSeccion = seccion.IdSeccion,
                DescripcionSeccion = seccion.DescripcionSeccion,
                IdEstante = seccion.IdEstante
            };

            _context.Seccions.Add(modelSeccion);
            _context.SaveChanges();
            return seccion;
        }

        public Models.Seccion BuscarPorId(int id)
        {
            var dbSeccion = _context.Seccions.FirstOrDefault(e => e.IdSeccion == id);
            if (dbSeccion != null)
            {
                var seccion = new Models.Seccion
                (
                    dbSeccion.IdSeccion,
                    dbSeccion.DescripcionSeccion,
                    dbSeccion.IdEstante
                );
                return seccion;
            }
            return null;
        }

        public List<Models.Seccion> GetAll()
        {
            var dbSeccions = _context.Seccions.ToList();
            var modelSeccions = new List<Models.Seccion>();
            foreach (var dbSeccion in dbSeccions)
            {
                modelSeccions.Add(new Models.Seccion
                {
                    dbSeccion.IdSeccion,
                    dbSeccion.DescripcionSeccion,
                    dbSeccion.IdEstante
                });
            }
            return modelSeccions;
        }

        public void Editar(Models.Seccion seccion)
        {
            var dbSeccion = _context.Seccions.FirstOrDefault(e => e.IdSeccion == seccion.IdSeccion);
            if (dbSeccion != null)
            {
                dbSeccion.DescripcionSeccion = seccion.DescripcionSeccion;
                dbSeccion.IdEstante = seccion.IdEstante;
                _context.SaveChanges();
            }
        }

        public void Borrar(int seccionId)
        {
            Seccion seccion = _context.Seccions.Find(seccionId);
            if (seccion != null)
            {
                _context.Seccions.Remove(seccion);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró la seccion con el ID especificado");
            }
        }

    }
}