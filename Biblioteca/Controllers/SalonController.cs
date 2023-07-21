using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;


namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/salones")]
    public class SalonController : ControllerBase
    {
        private SalonService _salonService;

        public SalonController(SalonService salonService)
        {
            _salonService = salonService;
        }

        /// GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var salones = _salonService.GetAllSalones();
            return Ok(salones);
        }

        /// ADD
        [HttpPost]
        public IActionResult Insertar([FromBody] Salon salon)
        {
            var nuevoSalon = _salonService.InsertarSalon(salon.IdSalon, salon.DescripcionSalon);
            return Ok(nuevoSalon);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Salon salonActualizado)
        {
            var salonActual = _salonService.BuscarSalonPorId(id);
            if (salonActual == null || salonActualizado == null)
            {
                return NotFound();
            }
            salonActual.DescripcionSalon = salonActualizado.DescripcionSalon;

            _salonService.EditarSalon(salonActual);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("/{id}")]
        public IActionResult Borrar(int id)
        {
            _salonService.BorrarSalon(id);
            return Ok();
        }
    }
}
