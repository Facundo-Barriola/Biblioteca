using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Repositories
{
    public interface IEstanteRepository
    {
    Estante GetById(int id);
    IEnumerable<Estante> GetAll();
    void Add(Estante estante);
    void Update(Estante estante);
    void Delete(Estante estante);
    }
}
