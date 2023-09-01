using DAL;
using ET.DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GPU_BL
    {
        private GPU_DAL dal = new ();
        public bool IngresarGPU(GPU gpu)
        {
            string descripcion = string.Empty;
            DataTable listGPU = dal.BuscarGPU();
            for (int i = 0; i < listGPU.Rows.Count; i++)
            {
                descripcion = listGPU.Rows[i]["DESCRIPCION_GPU"].ToString();
                if (descripcion.Equals(gpu.Descripcion))
                    return false;
            }
            return dal.IngresarGPU(gpu);
        }
        public bool ActualizarGPU(GPU gpu)
        {
            return dal.ActualizarGPU(gpu);
        }
        public bool EliminarGPU(int id)
        {
            return dal.EliminarGPU(id);
        }
        public List<GPU_DTO> BuscarGPU() 
        {
            List<GPU_DTO> retVal = new ();
            DataTable dt = dal.BuscarGPU();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GPU_DTO gpu = new();
                gpu.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                gpu.descripcion = dt.Rows[i]["DESCRIPCION_GPU"].ToString();
                gpu.cantidadConectores = Convert.ToInt32(dt.Rows[i]["CANTIDAD_CONECTORES"]);
                gpu.pcie16 = Convert.ToBoolean(dt.Rows[i]["PCIE16"]);
                gpu.consumoEnergia = Convert.ToDouble(dt.Rows[i]["CONSUMO_ENERGIA"]);
                retVal.Add(gpu);
            }
            return retVal;
        }
    }
}
