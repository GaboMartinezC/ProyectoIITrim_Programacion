using ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AlmacenamientoDAL : Conexion
    {
        public bool IngresarAlmacenamiento(Almacenamiento almacenamiento)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpIngresarAlmacenamiento", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descrip", almacenamiento.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@capacidad", almacenamiento.Capacidad));
                        cmd.Parameters.Add(new SqlParameter("@m2", almacenamiento.M2));
                        cmd.Parameters.Add(new SqlParameter("@consumo", almacenamiento.ConsumoEnergia));
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
        public bool ActualizarAlmacenamiento(Almacenamiento almacenamiento)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpActualizarAlmacenamiento", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", almacenamiento.Id));
                        cmd.Parameters.Add(new SqlParameter("@descrip", almacenamiento.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@capacidad", almacenamiento.Capacidad));
                        cmd.Parameters.Add(new SqlParameter("@m2", almacenamiento.M2));
                        cmd.Parameters.Add(new SqlParameter("@consumo", almacenamiento.ConsumoEnergia));
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
        public DataTable BuscarAlmacenamiento()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarAlmacenamiento", cn))
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
        public DataTable BuscarAlmacenamiento(int id)
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarAlmacenamiento", cn))
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
        public bool EliminarAlmacenamiento(int id)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpEliminarAlmacenamiento", cn))
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
    }
}
