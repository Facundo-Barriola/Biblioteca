using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface ISeccionRepository
    {
        Seccion GetById(int id);
        IEnumerable<Seccion> GetAll();
        void Add(Seccion seccion);
        void Update(Seccion seccion);
        void Delete(Seccion seccion);
    }
}
