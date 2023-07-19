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
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prestamo>> GetAllPrestamos()
        {
            var prestamos = _prestamoService.GetAllPrestamos();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public ActionResult<Prestamo> GetPrestamoById(int id)
        {
            var prestamo = _prestamoService.GetPrestamoById(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return Ok(prestamo);
        }

        [HttpPost]
        public IActionResult AddPrestamo([FromBody] Prestamo prestamo)
        {
            _prestamoService.AddPrestamo(prestamo.IdPrestamo, prestamo.FechaExtraccion, prestamo.FechaDevolucion, prestamo.FechaPactada, prestamo.EstadoPrestamo, prestamo.IdUsuario);
            return CreatedAtAction(nameof(GetPrestamoById), new { id = prestamo.IdPrestamo }, prestamo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePrestamo(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return BadRequest();
            }

            _prestamoService.UpdatePrestamo(prestamo.IdPrestamo, prestamo.FechaExtraccion, prestamo.FechaDevolucion, prestamo.FechaPactada, prestamo.EstadoPrestamo, prestamo.IdUsuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrestamo(int id)
        {
            _prestamoService.DeletePrestamo(id);
            return NoContent();
        }
    }
}
