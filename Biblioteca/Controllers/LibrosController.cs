using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private LibroService _libroService;
        public LibrosController(LibroService libroService) 
        {
            _libroService = libroService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var libros = _libroService.GetAllLibros();
            return Ok(libros);
        }

        [HttpDelete("/{id}")]
        public IActionResult Borrar(int id) 
        {
            _libroService.BorrarLibro(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Insertar([FromBody]Libro libro) 
        {
            var nuevoLibro = _libroService.InsertarLibro(libro.IdLibro, libro.Titulo, libro.Sinopsis,
                libro.PuntajeCritica, libro.Estado, libro.Disponibilidad, libro.IdSeccion);
            return Ok(nuevoLibro);//CreatedAtAction(nameof(), new {id = nuevoLibro.IdLibro});
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Libro libroActualizado) 
        {
            var libroExistente = _libroService.BuscarLibroPorId(id);

            if (libroExistente == null) 
            {
                return NotFound();
            }
            libroExistente.Titulo = libroActualizado.Titulo;
            libroExistente.Sinopsis = libroActualizado.Sinopsis;
            libroExistente.PuntajeCritica = libroActualizado.PuntajeCritica;
            libroExistente.Estado = libroActualizado.Estado;
            libroExistente.Disponibilidad = libroActualizado.Disponibilidad;
            libroExistente.IdSeccion = libroActualizado.IdSeccion;

            _libroService.EditarLibro(libroExistente);

            return NoContent();
        }
    }
}
