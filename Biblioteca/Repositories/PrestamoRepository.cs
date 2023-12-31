﻿using BibliotecaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace Biblioteca.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private BibliotecaContext _context;

        public PrestamoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public Models.Prestamo Insertar(Models.Prestamo prestamo)
        {
            var modelPrestamo = new Models.Prestamo(prestamo.IdPrestamo, prestamo.FechaExtraccion, prestamo.FechaDevolucion, prestamo.FechaPactada, prestamo.EstadoPrestamo, prestamo.IdUsuario);
            var dbPrestamo = new BibliotecaDB.Prestamo
            {
                IdPrestamo = prestamo.IdPrestamo,
                FechaExtraccion = prestamo.FechaExtraccion,
                FechaDevolucion = prestamo.FechaDevolucion,
                FechaPactada = prestamo.FechaPactada,
                EstadoPrestamo = prestamo.EstadoPrestamo,
                IdUsuario = prestamo.IdUsuario
            };

            modelPrestamo.UpdateIdPrestamo(dbPrestamo.IdPrestamo);
            _context.Prestamos.Add(dbPrestamo);
            _context.SaveChanges();
            return prestamo;
        }

        public Models.Prestamo BuscarPorId(int id)
        {
            var dbPrestamo = _context.Prestamos.FirstOrDefault(e => e.IdPrestamo == id);
            if (dbPrestamo != null)
            {
                var prestamo = new Models.Prestamo
                (
                    dbPrestamo.IdPrestamo,
                    dbPrestamo.FechaExtraccion,
                    dbPrestamo.FechaDevolucion,
                    dbPrestamo.FechaPactada,
                    dbPrestamo.EstadoPrestamo,
                    dbPrestamo.IdUsuario

                );
                return prestamo;
            }
            return null;
        }

        public List<Models.Prestamo> GetAll()
        {
            var dbPrestamos = _context.Prestamos.ToList();
            var modelPrestamos = new List<Models.Prestamo>();
            foreach (var dbPrestamo in dbPrestamos)
            {
                modelPrestamos.Add(new Models.Prestamo
                (
                    dbPrestamo.IdPrestamo,
                    dbPrestamo.FechaExtraccion,
                    dbPrestamo.FechaDevolucion,
                    dbPrestamo.FechaPactada,
                    dbPrestamo.EstadoPrestamo,
                    dbPrestamo.IdUsuario
                ));
            }
            return modelPrestamos;
        }

        public void Editar(Models.Prestamo prestamo)
        {
            var dbPrestamo = _context.Prestamos.FirstOrDefault(e => e.IdPrestamo == prestamo.IdPrestamo);
            if (dbPrestamo != null)
            {
                dbPrestamo.FechaExtraccion = prestamo.FechaExtraccion;
                dbPrestamo.FechaDevolucion = prestamo.FechaDevolucion;
                dbPrestamo.FechaPactada = prestamo.FechaPactada;
                dbPrestamo.EstadoPrestamo = prestamo.EstadoPrestamo;
                dbPrestamo.IdUsuario = prestamo.IdUsuario;

                _context.SaveChanges();
            }
        }

        public void Borrar(int prestamoId)
        {
            Prestamo prestamo = _context.Prestamos.Find(prestamoId);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró el prestamo con el ID especificado");
            }
        }

    }
}