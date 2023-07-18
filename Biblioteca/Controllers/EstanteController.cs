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
        private readonly EstanteService _estanteService;

        public EstanteController(EstanteService estanteService)
        {
            _estanteService = estanteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estante>> GetAllEstantes()
        {
            var estantes = _estanteService.GetAllEstantes();
            return Ok(estantes);
        }

        [HttpGet("{id}")]
        public ActionResult<Estante> GetEstanteById(int id)
        {
            var estante = _estanteService.GetEstanteById(id);
            if (estante == null)
            {
                return NotFound();
            }
            return Ok(estante);
        }

        [HttpPost]
        public IActionResult AddEstante([FromBody] Estante estante)
        {
            _estanteService.AddEstante(estante.IdEstante, estante.DescripcionEstante, estante.IdEstanteria);
            return CreatedAtAction(nameof(GetEstanteById), new { id = estante.IdEstante }, estante);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstante(int id, [FromBody] Estante estante)
        {
            if (id != estante.IdEstante)
            {
                return BadRequest();
            }

            _estanteService.UpdateEstante(estante.IdEstante, estante.DescripcionEstante, estante.IdEstanteria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstante(int id)
        {
            _estanteService.DeleteEstante(id);
            return NoContent();
        }
    }
}
