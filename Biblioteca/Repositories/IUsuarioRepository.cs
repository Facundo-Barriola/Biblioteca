using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> TraerTodos();
        Usuario Insertar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        void Borrar(int idUsuario);
        Usuario BuscarPorId(int id);
    }
}
