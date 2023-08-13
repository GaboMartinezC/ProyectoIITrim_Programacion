using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class EnsamblajeDAL : Conexion
    {
        public bool IngresarEnsamblaje(Ensamblaje ensamblaje)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpIngresarEnsamblaje", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@placa", ensamblaje.IdPlacaMadre));
                        cmd.Parameters.Add(new SqlParameter("@proce", ensamblaje.IdProcesador));
                        cmd.Parameters.Add(new SqlParameter("@enfriamiento", ensamblaje.IdEnfriamiento));
                        cmd.Parameters.Add(new SqlParameter("@ram", ensamblaje.IdRam));
                        cmd.Parameters.Add(new SqlParameter("@cantRam", ensamblaje.CantidadRam));
                        cmd.Parameters.Add(new SqlParameter("@grafica", ensamblaje.IdGrafica));
                        cmd.Parameters.Add(new SqlParameter("@casePc", ensamblaje.IdCase));
                        cmd.Parameters.Add(new SqlParameter("@alm", ensamblaje.IdUnidadAlmacenamiento));
                        cmd.Parameters.Add(new SqlParameter("@cantAlm", ensamblaje.CantidadUnidades));
                        cmd.Parameters.Add(new SqlParameter("@fuente", ensamblaje.IdFuente));
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retVal = false;
                }
            }
            return retVal;
        }
        public bool ActualizarEnsamblaje(Ensamblaje ensamblaje)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpActualizarEnsamblaje", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", ensamblaje.Id));
                        cmd.Parameters.Add(new SqlParameter("@placa", ensamblaje.IdPlacaMadre));
                        cmd.Parameters.Add(new SqlParameter("@proce", ensamblaje.IdProcesador));
                        cmd.Parameters.Add(new SqlParameter("@enfriamiento", ensamblaje.IdEnfriamiento));
                        cmd.Parameters.Add(new SqlParameter("@ram", ensamblaje.IdRam));
                        cmd.Parameters.Add(new SqlParameter("@cantRam", ensamblaje.CantidadRam));
                        cmd.Parameters.Add(new SqlParameter("@grafica", ensamblaje.IdGrafica));
                        cmd.Parameters.Add(new SqlParameter("@casePc", ensamblaje.IdCase));
                        cmd.Parameters.Add(new SqlParameter("@alm", ensamblaje.IdUnidadAlmacenamiento));
                        cmd.Parameters.Add(new SqlParameter("@cantAlm", ensamblaje.CantidadUnidades));
                        cmd.Parameters.Add(new SqlParameter("@fuente", ensamblaje.IdFuente));
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retVal = false;
                }
            }
            return retVal;
        }
        public bool EliminarEnsamblaje(int id)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpEliminarEnsamblaje", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retVal = false;
                }
            }
            return retVal;
        }
        public DataTable BuscarEnsamblaje()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarEnsamblaje", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(retVal);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return retVal;
        }
    }
}
