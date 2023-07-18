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
        private readonly SalonService _salonService;

        public SalonController(SalonService salonService)
        {
            _salonService = salonService;
        }

        /// GETALL
        [HttpGet]
        public ActionResult<IEnumerable<Salon>> GetAllSalones()
        {
            var salones = _salonService.GetAllSalones();
            return Ok(salones);
        }

        /// GETBYID
        [HttpGet("{id}")]
        public ActionResult<Salon> GetSalonById(int id)
        {
            var salon = _salonService.GetSalonById(id);
            if (salon == null)
            {
                return NotFound();
            }
            return Ok(salon);
        }

        /// ADD
        [HttpPost]
        public IActionResult AddSalon([FromBody] Salon salon)
        {
            _salonService.AddSalon(salon.IdSalon, salon.DescripcionSalon);
            return CreatedAtAction(nameof(GetSalonById), new { id = salon.IdSalon }, salon);
        }

        /// UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateSalon(int id, [FromBody] Salon salon)
        {
            if (id != salon.IdSalon)
            {
                return BadRequest();
            }

            _salonService.UpdateSalon(salon.IdSalon, salon.DescripcionSalon);
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteSalon(int id)
        {
            _salonService.DeleteSalon(id);
            return NoContent();
        }
    }
}
