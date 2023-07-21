using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private BibliotecaContext _bibliotecaContext;

        public SalonRepository(BibliotecaContext context)
        {
            _bibliotecaContext = context;
        }

        public Models.Salon Insertar(Models.Salon salon)
        {
            var modelSalon = new Models.Salon(salon.IdSalon, salon.DescripcionSalon);
            var dbSalon = new BibliotecaDB.Salon
            {
                IdSalon = salon.IdSalon,
                DescripcionSalon = salon.DescripcionSalon
            };

            modelSalon.UpdateIdSalon(dbSalon.IdSalon);
            _bibliotecaContext.Salones.Add(dbSalon);
            _bibliotecaContext.SaveChanges();
            return salon;
        }

        public void Borrar(int salonId)
        {
            Salon salon = _bibliotecaContext.Salones.Find(salonId);
            if (salon != null)
            {
                _bibliotecaContext.Salones.Remove(salon);
                _bibliotecaContext.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró el salón con el ID especificado");
            }
        }

        public List<Models.Salon> GetAll()
        {
            var dbSalones = _bibliotecaContext.Salones.ToList();
            var modelSalones = new List<Models.Salon>();
            foreach (var dbSalon in dbSalones)
            {
                modelSalones.Add(new Models.Salon
                (
                    dbSalon.IdSalon,
                    dbSalon.DescripcionSalon
                    ));
            }
            return modelSalones;
        }

        public void Editar(Models.Salon salon)
        {
            var dbSalon = _bibliotecaContext.Salones.FirstOrDefault(s => s.IdSalon == salon.IdSalon);
            if (dbSalon != null)
            {
                dbSalon.DescripcionSalon = salon.DescripcionSalon;
                _bibliotecaContext.SaveChanges();
            }
        }

        public Models.Salon BuscarPorId(int idSalon)
        {
            var dbSalon = _bibliotecaContext.Salones.FirstOrDefault(s => s.IdSalon == idSalon);
            if (dbSalon != null)
            {
                var salon = new Models.Salon
                (
                    dbSalon.IdSalon,
                    dbSalon.DescripcionSalon
                );
                return salon;
            }
            return null;
        }
    }
}