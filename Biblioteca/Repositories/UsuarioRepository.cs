using BibliotecaDB;
using System.Linq;

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
            Usuario usuario = _bibliotecaContext.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                _bibliotecaContext.Usuarios.Remove(usuario);
                _bibliotecaContext.SaveChanges();
            }
            else 
            {
                throw new Exception("No se encontró el libro con el ID especificado");
            }
        }

        public Models.Usuario BuscarPorId(int id)
        {
            Usuario dbUsuario = _bibliotecaContext.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (dbUsuario != null) 
            {
                var usuario = new Models.Usuario(
                    dbUsuario.IdUsuario,
                    dbUsuario.Dni,
                    dbUsuario.Nombre,
                    dbUsuario.Apellido,
                    dbUsuario.FechaNacimiento,
                    dbUsuario.Telefono,
                    dbUsuario.Mail,
                    dbUsuario.Contrasena,
                    dbUsuario.Tipo
                    );
                return usuario;
            }
            return null;
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
