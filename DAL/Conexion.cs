using System.Data.SqlClient;
namespace DAL
{
    public class Conexion
    {
        private readonly string _connectionString;
        public Conexion()
        {
            try
            {
                _connectionString = (@"Server=DESKTOP-9G4D1TG;Database=GabrielMartinezCamareno11E_ProyectoBD;Trusted_Connection=true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}