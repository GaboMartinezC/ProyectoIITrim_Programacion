using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ET;
using System.Data;
using ET.DTO;

namespace DAL
{
    public class RAM_DAL : Conexion
    {
        public bool IngresarRAM(RAM ram)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpIngresarRAM", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descrip", ram.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@versDDR", ram.VersionDDR));
                        cmd.Parameters.Add(new SqlParameter("@capacidad", ram.Capacidad));
                        cmd.Parameters.Add(new SqlParameter("@consumo", ram.ConsumoEnergia));
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
        public bool ActualizarRAM(RAM ram)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpActualizarRAM", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", ram.Id));
                        cmd.Parameters.Add(new SqlParameter("@descrip", ram.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@versDDR", ram.VersionDDR));
                        cmd.Parameters.Add(new SqlParameter("@capacidad", ram.Capacidad));
                        cmd.Parameters.Add(new SqlParameter("@consumo", ram.ConsumoEnergia));
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
        public DataTable BuscarRAM()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarRam", cn))
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
        public RAM BuscarRAM(int id)
        {
            RAM retVal = new();
            DataTable dt = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarRam", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            retVal.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                            retVal.Descripcion = dt.Rows[i]["DESCRIPCION_RAM"].ToString();
                            retVal.VersionDDR = Convert.ToInt32(dt.Rows[i]["VERSION_DDR"]);
                            retVal.Capacidad = Convert.ToInt32(dt.Rows[i]["CAPACIDAD"]);
                            retVal.ConsumoEnergia = Convert.ToInt32(dt.Rows[i]["CONSUMO_ENERGIA"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return retVal;
        }
        public bool EliminarRAM(int id)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpEliminarRAM", cn))
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
