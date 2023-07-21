﻿using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Linq;

namespace Biblioteca.Services
{
    public class LibroService 
    {
        private ILibroRepository _libroRepository;
        private ISeccionRepository _seccionRepository;
        private IEstanteRepository _estanteRepository;
        private IEstanteriaRepository _estanteriaRepository;
        private ISalonRepository _salonRepository;

        public LibroService(ILibroRepository libroRepository) 
        {
            _libroRepository = libroRepository;
        }
        public List<Libro> GetAllLibros()
        {
            return _libroRepository.GetAll();
        }

        public Libro InsertarLibro(int id, string titulo, string sinopsis, int puntajeCritica,
            int estado, bool disponibilidad, int idSeccion) 
        {   
            Libro libro = new Libro(id, titulo, sinopsis, puntajeCritica,
                estado, disponibilidad, idSeccion);
            return _libroRepository.Insertar(libro);
        }

        public void BorrarLibro(int idLibro) 
        {
            _libroRepository.Borrar(idLibro);
        }

        public void EditarLibro(Libro libro) {
            _libroRepository.Editar(libro);
        }

        public Libro BuscarLibroPorId(int idLibro) 
        {
            return _libroRepository.BuscarPorId(idLibro);
        }

        public string UbicacionLibro(Libro libro) 
        {
            var libroBuscado = _libroRepository.BuscarPorId(libro.IdLibro);

            if(libroBuscado != null) 
            {
                var ubicacionLibro = (from libros in _libroRepository.GetAll()
                                      join seccion in _seccionRepository.GetAll() on libro.IdSeccion equals seccion.IdSeccion
                                      join estante in _estanteRepository.GetAll() on seccion.IdEstante equals estante.IdEstante
                                      join estanteria in _estanteriaRepository.GetAll() on estante.IdEstanteria equals estanteria.IdEstanteria
                                      join salon in _salonRepository.GetAll() on estanteria.IdSalon equals salon.IdSalon
                                      where libros.IdLibro == libro.IdLibro
                                      select new
                                      {
                                          Salon = salon.DescripcionSalon,
                                          Estanteria = estanteria.DescripcionEstanteria,
                                          Estante = estante.DescripcionEstante,
                                          Seccion = seccion.DescripcionSeccion
                                      }).FirstOrDefault();

                if (libroBuscado != null) 
                {
                    return $"Ubicacion del libro: {ubicacionLibro.Salon}, {ubicacionLibro.Estanteria}, {ubicacionLibro.Estante}," +
                        $" {ubicacionLibro.Seccion}";
                }
            }
            return "Libro no enconrtado";
        }
    }
}
