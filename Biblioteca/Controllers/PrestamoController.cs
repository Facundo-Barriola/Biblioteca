using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/prestamos")]
    public class PrestamoController : ControllerBase
    {
        private PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var prestamos = _prestamoService.GetAllPrestamos();
            return Ok(prestamos);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] Prestamo prestamo)
        {
            var nuevoPrestamo = _prestamoService.InsertarPrestamo(prestamo.IdPrestamo, prestamo.FechaExtraccion, prestamo.FechaDevolucion, prestamo.FechaPactada, prestamo.EstadoPrestamo, prestamo.IdUsuario);
            return Ok(nuevoPrestamo);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Prestamo prestamoActualizado)
        {
            var prestamoActual = _prestamoService.BuscarPrestamoPorId(id);
            if (prestamoActual == null || prestamoActualizado == null)
            {
                return NotFound();
            }
            prestamoActual.FechaExtraccion = prestamoActualizado.FechaExtraccion;
            prestamoActual.FechaDevolucion = prestamoActualizado.FechaDevolucion;
            prestamoActual.FechaPactada = prestamoActualizado.FechaPactada;
            prestamoActual.EstadoPrestamo = prestamoActualizado.EstadoPrestamo;
            prestamoActual.IdUsuario = prestamoActualizado.IdUsuario;
            _prestamoService.EditarPrestamo(prestamoActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            _prestamoService.BorrarPrestamo(id);
            return Ok();
        }
    }
}