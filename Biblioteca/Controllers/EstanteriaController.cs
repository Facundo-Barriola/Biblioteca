using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/estanterias")]
    public class EstanteriaController : ControllerBase
    {
        private EstanteriaService _estanteriaService;

        public EstanteriaController(EstanteriaService estanteriaService)
        {
            _estanteriaService = estanteriaService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var estanterias = _estanteriaService.GetAllEstanterias();
            return Ok(estanterias);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] Estanteria estanteria)
        {
            var nuevaEstanteria = _estanteriaService.InsertarEstanteria(estanteria.IdEstanteria, estanteria.DescripcionEstanteria, estanteria.IdSalon);
            return Ok(nuevaEstanteria);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Estanteria estanteriaActualizada)
        {
            var estanteriaActual = _estanteriaService.BuscarEstanteriaPorId(id);
            if (estanteriaActual == null || estanteriaActualizada == null)
            {
                return NotFound();
            }
            estanteriaActual.DescripcionEstanteria = estanteriaActualizada.DescripcionEstanteria;
            estanteriaActual.IdSalon = estanteriaActualizada.IdSalon;

            _estanteriaService.EditarEstanteria(estanteriaActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            _estanteriaService.BorrarEstanteria(id);
            return Ok();
        }
    }
}
