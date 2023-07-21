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
        private PrestamoLibroService _prestamoLibroService;

        public PrestamoLibroController(PrestamoLibroService prestamoLibroService)
        {
            _prestamoLibroService = prestamoLibroService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var prestamoLibros = _prestamoLibroService.GetAllPrestamoLibros();
            return Ok(prestamoLibros);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] PrestamoLibro prestamoLibro)
        {
            var nuevaPrestamoLibro = _prestamoLibroService.InsertarPrestamoLibro(prestamoLibro.IdPrestamoLibro, prestamoLibro.IdPrestamo, prestamoLibro.IdLibro);
            return Ok(nuevaPrestamoLibro);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] PrestamoLibro prestamoLibroActualizada)
        {
            var prestamoLibroActual = _prestamoLibroService.BuscarPrestamoLibroPorId(id);
            if (prestamoLibroActual == null || prestamoLibroActualizada == null)
            {
                return NotFound();
            }
            prestamoLibroActual.IdPrestamo = prestamoLibroActualizada.IdPrestamo;
            prestamoLibroActual.IdLibro = prestamoLibroActualizada.IdLibro;

            _prestamoLibroService.EditarPrestamoLibro(prestamoLibroActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            _prestamoLibroService.BorrarPrestamoLibro(id);
            return Ok();
        }
    }
}