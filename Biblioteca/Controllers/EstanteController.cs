using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/estantes")]
    public class EstanteController : ControllerBase
    {
        private EstanteService _estanteService;

        public EstanteController(EstanteService estanteService)
        {
            _estanteService = estanteService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var estantes = _estanteService.GetAllEstantes();
            return Ok(estantes);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] Estante estante)
        {
            var nuevaEstante = _estanteService.InsertarEstante(estante.IdEstante, estante.DescripcionEstante, estante.IdEstanteria);
            return Ok(nuevaEstante);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Estante estanteActualizada)
        {
            var estanteActual = _estanteService.BuscarEstantePorId(id);
            if (estanteActual == null || estanteActualizada == null)
            {
                return NotFound();
            }
            estanteActual.DescripcionEstante = estanteActualizada.DescripcionEstante;
            estanteActual.IdEstanteria = estanteActualizada.IdEstanteria;

            _estanteService.EditarEstante(estanteActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            _estanteService.BorrarEstante(id);
            return Ok();
        }
    }
}