using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services
{
    public class UsuarioService
    {
        private UsuarioRepository _usuarioRepository;
        public UsuarioService(UsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> TraerTodosUsuarios() 
        {
            return _usuarioRepository.TraerTodos();
        }

        public Usuario InsertarUsuario(Usuario usuario) 
        {
            return _usuarioRepository.Insertar(usuario);
        }

        public void BorrarUsuario(int idUsuario) 
        {
            _usuarioRepository.Borrar(idUsuario);
        }

        public Usuario EditarUsuario(Usuario usuario) 
        {
            return _usuarioRepository.Editar(usuario); 
        }

        public Usuario BuscarUsuarioPorId(int id) 
        {
            return _usuarioRepository.BuscarPorId(id);
        }
    }
}
