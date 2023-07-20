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
            var dbUsuario = _bibliotecaContext.Usuarios.FirstOrDefault(u => u.IdUsuario == usuario.IdUsuario);
            if (dbUsuario != null) 
            {
                dbUsuario.Dni = usuario.Dni;
                dbUsuario.Nombre = usuario.Nombre;
                dbUsuario.Apellido = usuario.Apellido;
                dbUsuario.FechaNacimiento = usuario.FechaNacimiento;
                dbUsuario.Telefono = usuario.Telefono;
                dbUsuario.Mail = usuario.Mail;
                dbUsuario.Contrasena = usuario.Contrasena;
                dbUsuario.Tipo = usuario.Tipo;
                _bibliotecaContext.SaveChanges();
            }
            return usuario;
        }

        public Models.Usuario Insertar(Models.Usuario usuario)
        {
            var modelUsuario = new Models.Usuario(usuario.IdUsuario,usuario.Dni ,usuario.Nombre, 
                usuario.Apellido, usuario.FechaNacimiento, usuario.Telefono, usuario.Mail,
                usuario.Contrasena, usuario.Tipo);
            var dbUsuario = new BibliotecaDB.Usuario 
            {
                Dni = usuario.Dni,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Telefono = usuario.Telefono,
                Mail = usuario.Mail,
                Contrasena = usuario.Contrasena,
                Tipo = usuario.Tipo
            };
            modelUsuario.EditarId(dbUsuario.IdUsuario);
            _bibliotecaContext.Usuarios.Add(dbUsuario);
            _bibliotecaContext.SaveChanges();
            return usuario;
        }

        public List<Models.Usuario> TraerTodos()
        {
            var dbUsuarios = _bibliotecaContext.Usuarios.ToList();
            var modelUsuarios = new List<Models.Usuario>();
            foreach (var dbUsuario in dbUsuarios) 
            {
                modelUsuarios.Add(new Models.Usuario
                    (
                        dbUsuario.IdUsuario,
                        dbUsuario.Dni,
                        dbUsuario.Nombre,
                        dbUsuario.Apellido,
                        dbUsuario.FechaNacimiento,
                        dbUsuario.Telefono,
                        dbUsuario.Mail,
                        dbUsuario.Contrasena,
                        dbUsuario.Tipo
                    ));
            }
            return modelUsuarios;
        }
    }
}
