﻿using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private LibroService _libroService;
        public LibrosController(LibroService libroService) 
        {
            _libroService = libroService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var libros = _libroService.GetAllLibros();
            return Ok(libros);
        }
        
    }
}