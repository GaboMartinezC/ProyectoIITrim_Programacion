using DAL;
using ET;
using ET.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PlacaMadreBL
    {
        private PlacaMadreDAL dal = new();
        public bool IngresarPlacaMadre(PlacaMadre placa)
        {
            string descripcion = string.Empty;
            DataTable listFactorForma = dal.BuscarPlacaMadre();
            for (int i = 0; i < listFactorForma.Rows.Count; i++)
            {
                descripcion = listFactorForma.Rows[i]["DESCRIPCION_PLACA"].ToString();
                if (descripcion.Equals(placa.Descripcion))
                    return false;
            }
            return dal.IngresarPlacaMadre(placa);
        }
        public bool ActualizarPlacaMadre(PlacaMadre placa)
        {
            return dal.ActualizarPlacaMadre(placa);
        }
        public bool EliminarPlacaMadre(int id)
        {
            return dal.EliminarPlacaMadre(id);
        }
        public List<PlacaMadre_DTO> BuscarPlacaMadre()
        {
            List<PlacaMadre_DTO> retVal = new();
            DataTable dt = dal.BuscarPlacaMadre();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                PlacaMadre_DTO dto = new();
                dto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                dto.descripcion = dt.Rows[i]["DESCRIPCION_PLACA"].ToString();
                dto.idFactorForma = Convert.ToInt32(dt.Rows[i]["ID_FACTOR_FORMA"]);
                dto.descripFacForma = dt.Rows[i]["DESCRIPCION_FACTOR_FORMA"].ToString();
                dto.idSocket = Convert.ToInt32(dt.Rows[i]["ID_SOCKET"]);
                dto.descripSocket = dt.Rows[i]["DESCRIPCION_SOCKET"].ToString();
                dto.cantidadSATA = Convert.ToInt32(dt.Rows[i]["CANTIDAD_SATA"]);
                dto.cantidadPCIe8 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_PCIE8"]);
                dto.cantidadPCIe16 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_PCIE16"]);
                dto.cantidadM2 = Convert.ToInt32(dt.Rows[i]["CANTIDAD_M2"]);
                dto.versionDDR = Convert.ToInt32(dt.Rows[i]["VERSION_DDR"]);
                dto.cantidadSlotsRAM = Convert.ToInt32(dt.Rows[i]["CANTIDAD_SLOTS_RAM"]);
                dto.limiteRAM = Convert.ToInt32(dt.Rows[i]["LIMITE_RAM"]);
                dto.consumoEnergia = Convert.ToDouble(dt.Rows[i]["CONSUMO_ENERGIA"]);
                retVal.Add(dto);
            }
            return retVal; 
        }
        
    }
}
