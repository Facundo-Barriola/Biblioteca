using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface IPrestamoLibroRepository
    {
        PrestamoLibro GetById(int id);
        IEnumerable<PrestamoLibro> GetAll();
        void Add(PrestamoLibro prestamoLibro);
        void Update(PrestamoLibro prestamoLibro);
        void Delete(PrestamoLibro prestamoLibro);
    }
}