using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface IPrestamoRepository
    {
        Prestamo GetById(int id);
        IEnumerable<Prestamo> GetAll();
        void Add(Prestamo prestamo);
        void Update(Prestamo prestamo);
        void Delete(Prestamo prestamo);
    }
}
