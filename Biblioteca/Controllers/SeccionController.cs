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
        private SeccionService _seccionService;

        public SeccionController(SeccionService seccionService)
        {
            _seccionService = seccionService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var secciones = _seccionService.GetAllSecciones();
            return Ok(secciones);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] Seccion seccion)
        {
            var nuevaSeccion = _seccionService.InsertarSeccion(seccion.IdSeccion, seccion.DescripcionSeccion, seccion.IdEstante);
            return Ok(nuevaSeccion);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Seccion seccionActualizada)
        {
            var seccionActual = _seccionService.BuscarSeccionPorId(id);
            if (seccionActual == null || seccionActualizada == null)
            {
                return NotFound();
            }
            seccionActual.DescripcionSeccion = seccionActualizada.DescripcionSeccion;
            seccionActual.IdEstante = seccionActualizada.IdEstante;

            _seccionService.EditarSeccion(seccionActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            _seccionService.BorrarSeccion(id);
            return Ok();
        }
    }
}