using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/secciones")]
    public class SeccionController : ControllerBase
    {
        private readonly SeccionService _seccionService;

        public SeccionController(SeccionService seccionService)
        {
            _seccionService = seccionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Seccion>> GetAllSecciones()
        {
            var secciones = _seccionService.GetAllSecciones();
            return Ok(secciones);
        }

        [HttpGet("{id}")]
        public ActionResult<Seccion> GetSeccionById(int id)
        {
            var seccion = _seccionService.GetSeccionById(id);
            if (seccion == null)
            {
                return NotFound();
            }
            return Ok(seccion);
        }

        [HttpPost]
        public IActionResult AddSeccion([FromBody] Seccion seccion)
        {
            _seccionService.AddSeccion(seccion.IdSeccion, seccion.DescripcionSeccion, seccion.IdEstante);
            return CreatedAtAction(nameof(GetSeccionById), new { id = seccion.IdSeccion }, seccion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeccion(int id, [FromBody] Seccion seccion)
        {
            if (id != seccion.IdSeccion)
            {
                return BadRequest();
            }

            _seccionService.UpdateSeccion(seccion.IdSeccion, seccion.DescripcionSeccion, seccion.IdEstante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeccion(int id)
        {
            _seccionService.DeleteSeccion(id);
            return NoContent();
        }
    }
}
