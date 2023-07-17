using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public interface IEstanteriaRepository
    {
        Estanteria GetById(int id);
        IEnumerable<Estanteria> GetAll();
        void Add(Estanteria estanteria);
        void Update(Estanteria estanteria);
        void Delete(Estanteria estanteria);
    }
}
