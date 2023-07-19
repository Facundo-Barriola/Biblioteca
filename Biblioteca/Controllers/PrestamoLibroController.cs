using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/prestamoLibros")]
    public class PrestamoLibroController : ControllerBase
    {
        private readonly PrestamoLibroService _prestamoLibroService;

        public PrestamoLibroController(PrestamoLibroService prestamoLibroService)
        {
            _prestamoLibroService = prestamoLibroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PrestamoLibro>> GetAllPrestamosLibros()
        {
            var prestamosLibros = _prestamoLibroService.GetAllPrestamosLibros();
            return Ok(prestamosLibros);
        }

        [HttpGet("{id}")]
        public ActionResult<PrestamoLibro> GetPrestamoLibroById(int id)
        {
            var prestamoLibro = _prestamoLibroService.GetPrestamoLibroById(id);
            if (prestamoLibro == null)
            {
                return NotFound();
            }
            return Ok(prestamoLibro);
        }

        [HttpPost]
        public IActionResult AddPrestamoLibro([FromBody] PrestamoLibro prestamoLibro)
        {
            _prestamoLibroService.AddPrestamoLibro(prestamoLibro.IdPrestamoLibro, prestamoLibro.IdPrestamo, prestamoLibro.IdLibro);
            return CreatedAtAction(nameof(GetPrestamoLibroById), new { id = prestamoLibro.IdPrestamoLibro }, prestamoLibro);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePrestamoLibro(int id, [FromBody] PrestamoLibro prestamoLibro)
        {
            if (id != prestamoLibro.IdPrestamoLibro)
            {
                return BadRequest();
            }

            _prestamoLibroService.UpdatePrestamoLibro(prestamoLibro.IdPrestamoLibro, prestamoLibro.IdPrestamo, prestamoLibro.IdLibro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrestamoLibro(int id)
        {
            _prestamoLibroService.DeletePrestamoLibro(id);
            return NoContent();
        }
    }
}
