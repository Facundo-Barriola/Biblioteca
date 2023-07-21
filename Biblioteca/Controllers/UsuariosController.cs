using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController
    {
        private UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult TraerTodos()
        {
            _usuarioService.TraerTodosUsuarios();
            return Ok();
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Usuario usuario)
        {
            var nuevoUsuario = _usuarioService.InsertarUsuario(usuario.IdUsuario, usuario.Dni,
                usuario.Nombre, usuario.Apellido, usuario.FechaNacimiento, usuario.Telefono, usuario.Mail,
                usuario.Contrasena, usuario.Tipo);
            return CreatedAtAction(nameof(), new { id = nuevoUsuario.IdUsuario });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.BorrarUsuario(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Usuario usuarioActualizado) 
        {
            var usuarioExistente = _usuarioService.BuscarUsuarioPorId(id);
            if (usuarioExistente == null) 
            {
                return NotFound();
            }
            usuarioExistente.Dni = usuarioActualizado.Dni;
            usuarioExistente.Nombre = usuarioActualizado.Nombre;
            usuarioExistente.Apellido = usuarioActualizado.Apellido;
            usuarioExistente.FechaNacimiento = usuarioActualizado.FechaNacimiento;
            usuarioExistente.Telefono = usuarioActualizado.Telefono;
            usuarioExistente.Mail = usuarioActualizado.Mail;
            usuarioExistente.Contrasena = usuarioActualizado.Contrasena;
            usuarioActualizado.Tipo = usuarioActualizado.Tipo;
            _usuarioService.EditarUsuario(usuarioExistente);
            return NoContent();
        }
    }
}
