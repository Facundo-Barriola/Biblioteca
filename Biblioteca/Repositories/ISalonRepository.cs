using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface ISalonRepository
    {
        Salon GetById(int id);
        List<Salon> GetAll();
        Salon Add(Salon salon);
        Salon Update(Salon salon);
        void Delete(Salon salon);
    }
}