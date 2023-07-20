using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface ISalonRepository
    {
        Salon GetById(int id);
        IEnumerable<Salon> GetAll();
        void Add(Salon salon);
        void Update(Salon salon);
        void Delete(Salon salon);
    }
}