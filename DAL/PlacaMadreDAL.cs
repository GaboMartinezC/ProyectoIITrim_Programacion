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
    public class PlacaMadreDAL : Conexion
    {
        public DataTable BuscarPlacaMadre()
        {
            DataTable retVal = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarPlacaMadre", cn))
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
        public PlacaMadre BuscarPlacaMadre(int id)
        {
            PlacaMadre retVal = new();
            DataTable dt = new DataTable();
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpBuscarPlacaMadre", cn))
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
                                retVal.Descripcion = dt.Rows[i]["DESCRIPCION_PLACA"].ToString();
                                retVal.IdFactorForma = Convert.ToInt32(dt.Rows[i]["ID_FACTOR_FORMA"]);
                                retVal.IdSocket = Convert.ToInt32(dt.Rows[i]["ID_SOCKET"]);
                                retVal.CantidadSATA = Convert.ToInt32(dt.Rows[i]["CANTIDAD_SATA"]);
                                retVal.CantidadPCIe8 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_PCIE8"]);
                                retVal.CantidadPCIe16 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_PCIE16"]);
                                retVal.CantidadM2 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_M2"]);
                                retVal.VersionDDR = Convert.ToInt32(dt.Rows[i]["VERSION_DDR"]);
                                retVal.CantidadSlotsRAM = Convert.ToInt32(dt.Rows[i]["CANTIDAD_SLOTS_RAM"]);
                                retVal.LimiteRAM = Convert.ToInt32(dt.Rows[i]["LIMITE_RAM"]);
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
