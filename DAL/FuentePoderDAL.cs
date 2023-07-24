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
    public class FuentePoderDAL : Conexion
    {
        public bool IngresarFuentePoder(FuentePoder fuentePoder)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpIngresarFuente", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descrip", fuentePoder.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@cantidadSATA", fuentePoder.CantidadConectoresSATA));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPCIE", fuentePoder.CantidadConectoresPCIe));
                        cmd.Parameters.Add(new SqlParameter("@potencia", fuentePoder.Potencia));
                        cmd.Parameters.Add(new SqlParameter("@alto", fuentePoder.Altura));
                        cmd.Parameters.Add(new SqlParameter("@ancho", fuentePoder.Ancho));
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
        public bool ActualizarFuentePoder(FuentePoder fuentePoder)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpActualizarFuente", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", fuentePoder.Id));
                        cmd.Parameters.Add(new SqlParameter("@descrip", fuentePoder.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@cantidadSATA", fuentePoder.CantidadConectoresSATA));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPCIE", fuentePoder.CantidadConectoresPCIe));
                        cmd.Parameters.Add(new SqlParameter("@potencia", fuentePoder.Potencia));
                        cmd.Parameters.Add(new SqlParameter("@alto", fuentePoder.Altura));
                        cmd.Parameters.Add(new SqlParameter("@ancho", fuentePoder.Ancho));
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
        public DataTable BuscarFuentePoder()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarFuente", cn))
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
        public bool EliminarFuentePoder(int id)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpEliminarFuente", cn))
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
