using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibrosController(ILibroService libroService) 
        {
            _libroService = libroService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var libros = _libroService.GetAllLibros();
            return new JsonResult(libros) { StatusCode = 200 };
        }
        
    }
}
