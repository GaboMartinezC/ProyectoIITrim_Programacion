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
        public bool IngresarPlacaMadre(PlacaMadre placaMadre)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpIngresarPlacaMadre", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descrip", placaMadre.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@idFactorForma", placaMadre.IdFactorForma));
                        cmd.Parameters.Add(new SqlParameter("@idSocket", placaMadre.IdSocket));
                        cmd.Parameters.Add(new SqlParameter("@cantidadSATA", placaMadre.CantidadSATA));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPcie16", placaMadre.CantidadPCIe16));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPcie8", placaMadre.CantidadPCIe8));
                        cmd.Parameters.Add(new SqlParameter("@versionDDR", placaMadre.VersionDDR));
                        cmd.Parameters.Add(new SqlParameter("@cantSlotsRAM", placaMadre.CantidadSlotsRAM));
                        cmd.Parameters.Add(new SqlParameter("@limiteRAM", placaMadre.LimiteRAM));
                        cmd.Parameters.Add(new SqlParameter("@cantidadM2", placaMadre.CantidadM2));
                        cmd.Parameters.Add(new SqlParameter("@consumoEnergia", placaMadre.ConsumoEnergia));
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
        public bool ActualizarPlacaMadre(PlacaMadre placaMadre)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpActualizarPlacaMadre", cn))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", placaMadre.Id));
                        cmd.Parameters.Add(new SqlParameter("@descrip", placaMadre.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@idFactorForma", placaMadre.IdFactorForma));
                        cmd.Parameters.Add(new SqlParameter("@idSocket", placaMadre.IdSocket));
                        cmd.Parameters.Add(new SqlParameter("@cantidadSATA", placaMadre.CantidadSATA));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPcie16", placaMadre.CantidadPCIe16));
                        cmd.Parameters.Add(new SqlParameter("@cantidadPcie8", placaMadre.CantidadPCIe8));
                        cmd.Parameters.Add(new SqlParameter("@versionDDR", placaMadre.VersionDDR));
                        cmd.Parameters.Add(new SqlParameter("@cantSlotsRAM", placaMadre.CantidadSlotsRAM));
                        cmd.Parameters.Add(new SqlParameter("@limiteRAM", placaMadre.LimiteRAM));
                        cmd.Parameters.Add(new SqlParameter("@cantidadM2", placaMadre.CantidadM2));
                        cmd.Parameters.Add(new SqlParameter("@consumoEnergia", placaMadre.ConsumoEnergia));
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
        public bool EliminarPlacaMadre(int id)
        {
            bool retVal = false;
            using (var cn = GetConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SpEliminarPlacaMadre", cn))
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
