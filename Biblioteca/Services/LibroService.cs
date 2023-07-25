using Biblioteca.Models;
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

        public LibroService(ILibroRepository libroRepository, ISeccionRepository seccionRepository, IEstanteRepository estanteRepository,
            IEstanteriaRepository estanteriaRepository, ISalonRepository salonRepository) 
        {
            _libroRepository = libroRepository;
            _seccionRepository = seccionRepository;
            _estanteRepository = estanteRepository;
            _estanteriaRepository = estanteriaRepository;
            _salonRepository = salonRepository;
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

        public List<UbicacionLibro> UbicacionLibro() 
        {
           var ubicacionesLibro = (from libro in _libroRepository.GetAll()
                    join seccion in _seccionRepository.GetAll() on libro.IdSeccion equals seccion.IdSeccion
                    join estante in _estanteRepository.GetAll() on seccion.IdEstante equals estante.IdEstante
                    join estanteria in _estanteriaRepository.GetAll() on estante.IdEstanteria equals estanteria.IdEstanteria
                    join salon in _salonRepository.GetAll() on estanteria.IdSalon equals salon.IdSalon
                    select new UbicacionLibro 
                    {
                        Titulo = libro.Titulo,
                        DescripcionSalon = salon.DescripcionSalon,
                        DescripcionEstanteria = estanteria.DescripcionEstanteria,
                        DescripcionEstante = estante.DescripcionEstante,
                        DescripcionSeccion = seccion.DescripcionSeccion
                    }).ToList();
                return ubicacionesLibro;
            
        }
    }
}
