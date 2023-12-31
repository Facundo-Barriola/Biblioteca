﻿using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IEstanteriaRepository
    {
        List<Estanteria> GetAll();
        Estanteria Insertar(Estanteria Estanteria);
        void Editar(Estanteria Estanteria);
        void Borrar(int estanteriaId);
        Estanteria BuscarPorId(int estanteriaId);
    }
}
