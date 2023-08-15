using System;
using System.Collections.Generic;
using ET;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.DTO;

namespace DAL
{
    public class GPU_DAL : Conexion
    {
        public DataTable BuscarGPU()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarGPU", cn))
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
        public GPU BuscarGPU(int id)
        {
            GPU retVal = new();
            DataTable dt = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarGPU", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        { 
                            if (Convert.ToInt32(dt.Rows[i]["ID"]) == id)
                            {
                                retVal.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                                retVal.Descripcion = dt.Rows[i]["DESCRIPCION_GPU"].ToString();
                                retVal.CantidadConectores = Convert.ToInt32(dt.Rows[i]["CANTIDAD_CONECTORES"]);
                                retVal.Pcie16 = Convert.ToBoolean(dt.Rows[i]["PCIE16"]);
                                retVal.ConsumoEnergia = Convert.ToDouble(dt.Rows[i]["CONSUMO_ENERGIA"]);
                            }
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
    }
}
