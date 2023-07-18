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
        private readonly EstanteriaService _estanteriaService;

        public EstanteriaController(EstanteriaService estanteriaService)
        {
            _estanteriaService = estanteriaService;
        }

        // GETALL

        [HttpGet]
        public ActionResult<IEnumerable<Estanteria>> GetAllEstanterias()
        {
            var estanterias = _estanteriaService.GetAllEstanterias();
            return Ok(estanterias);
        }

        // GETBYID
        [HttpGet("{id}")]
        public ActionResult<Estanteria> GetEstanteriaById(int id)
        {
            var estanteria = _estanteriaService.GetEstanteriaById(id);
            if (estanteria == null)
            {
                return NotFound();
            }
            return Ok(estanteria);
        }

        // ADD
        [HttpPost]
        public IActionResult AddEstanteria([FromBody] Estanteria estanteria)
        {
            _estanteriaService.AddEstanteria(estanteria.IdEstanteria, estanteria.DescripcionEstanteria, estanteria.IdSalon);
            return CreatedAtAction(nameof(GetEstanteriaById), new { id = estanteria.IdEstanteria }, estanteria);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateEstanteria(int id, [FromBody] Estanteria estanteria)
        {
            if (id != estanteria.IdEstanteria)
            {
                return BadRequest();
            }

            _estanteriaService.UpdateEstanteria(estanteria.IdEstanteria, estanteria.DescripcionEstanteria, estanteria.IdSalon);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEstanteria(int id)
        {
            _estanteriaService.DeleteEstanteria(id);
            return NoContent();
        }
    }
}
