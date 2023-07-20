using Biblioteca.Models;
using Biblioteca.Repositories;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly ISeccionRepository _seccionRepository;
        private readonly IEstanteRepository _estanteRepository;
        private readonly IEstanteriaRepository _estanteriaRepository;
        private readonly ISalonRepository _salonRepository;

        public UbicacionService(
            ILibroRepository libroRepository,
            ISeccionRepository seccionRepository,
            IEstanteRepository estanteRepository,
            IEstanteriaRepository estanteriaRepository,
            ISalonRepository salonRepository)
        {
            _libroRepository = libroRepository;
            _seccionRepository = seccionRepository;
            _estanteRepository = estanteRepository;
            _estanteriaRepository = estanteriaRepository;
            _salonRepository = salonRepository;
        }

        public string ObtenerUbicacionLibro(int idLibro)
        {
            Libro libro = _libroRepository.GetById(idLibro);
            if (libro == null)
            {
                throw new Exception("El libro no existe");
            }

            Seccion seccion = _seccionRepository.GetById(libro.IdSeccion);
            if (seccion == null)
            {
                throw new Exception("La sección no existe");
            }

            Estante estante = _estanteRepository.GetById(seccion.IdEstante);
            if (estante == null)
            {
                throw new Exception("El estante no existe");
            }

            Estanteria estanteria = _estanteriaRepository.GetById(estante.IdEstanteria);
            if (estanteria == null)
            {
                throw new Exception("La estantería no existe");
            }

            Salon salon = _salonRepository.GetById(estanteria.IdSalon);
            if (salon == null)
            {
                throw new Exception("El salón no existe");
            }

            string ubicacion = $"Salón: {salon.Descripcion}, Estantería: {estanteria.Descripcion}, Estante: {estante.Descripcion}, Sección: {seccion.Descripcion}";
            return ubicacion;
        }
    }

    public interface IUbicacionService
    {
        string ObtenerUbicacionLibro(int idLibro);
    }
}
