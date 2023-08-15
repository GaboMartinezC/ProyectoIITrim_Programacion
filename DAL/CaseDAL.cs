using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ET;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.DTO;

namespace DAL
{
    public class CaseDAL : Conexion
    {
        public DataTable BuscarCase()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarCase", cn))
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
        public Case BuscarCase(int id)
        {
            Case retVal = new();
            DataTable dt = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarCase", cn))
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
                                retVal.Descripcion = dt.Rows[i]["DESCRIPCION_CASE"].ToString();
                                retVal.IdFactorForma = Convert.ToInt32(dt.Rows[i]["ID_FACTOR_FORMA"]);
                                retVal.RefrigeracionLiquida = Convert.ToBoolean(dt.Rows[i]["REFRIGERACION_LIQUIDA"]);
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
