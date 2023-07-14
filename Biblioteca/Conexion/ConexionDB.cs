namespace Biblioteca.Conexion
{
    public class ConexionDB
    {
        private string connectionString = string.Empty;
        public ConexionDB() 
        {
            // Construimos la conexión con la base de datos
            var constructor = new ConfigurationBuilder().SetBasePath
                    (Directory.GetCurrentDirectory()).AddJsonFile
                    ("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:conexionmaestra").Value;
        }

        public string cadenaSQL() 
        {
            return connectionString;
        }
    }
}
