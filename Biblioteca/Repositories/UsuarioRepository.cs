using BibliotecaDB;

namespace Biblioteca.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private BibliotecaContext _bibliotecaContext;

        public UsuarioRepository(BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public void Borrar(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Models.Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Usuario Editar(Models.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Models.Usuario Insertar(Models.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Models.Usuario> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
