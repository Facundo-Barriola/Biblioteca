using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/ubicaciones")]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet("{idLibro}")]
        public IActionResult ObtenerUbicacionLibro(int idLibro)
        {
            try
            {
                string ubicacion = _ubicacionService.ObtenerUbicacionLibro(idLibro);
                return Ok(ubicacion);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}