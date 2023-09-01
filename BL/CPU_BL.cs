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
    public class CPU_BL
    {
        private CPU_DAL dal = new();
        public bool IngresarCPU(CPU cpu)
        {
            //comentario
            string descripcion = string.Empty;
            DataTable listCpu = dal.BuscarCPU();
            for (int i = 0; i < listCpu.Rows.Count; i++)
            {
                descripcion = listCpu.Rows[i]["DESCRIPCION_CPU"].ToString();
                if (descripcion.Equals(cpu.Descripcion))
                    return false;
            }
            return dal.IngresarCPU(cpu);
        }
        public bool ActualizarCPU(CPU cpu)
        {
            return dal.ActualizarCPU(cpu);
        }
        public bool EliminarCPU(int id)
        {
            return dal.EliminarCPU(id);
        }
        public List<CPU_DTO> BuscarCPU()
        {
            List<CPU_DTO> retVal = new();
            DataTable dt = dal.BuscarCPU();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CPU_DTO cpu = new();
                cpu.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                cpu.descripcion = dt.Rows[i]["DESCRIPCION_CPU"].ToString();
                cpu.idSocket = Convert.ToInt32(dt.Rows[i]["ID_SOCKET"]); 
                cpu.descripcionSocket = dt.Rows[i]["DESCRIPCION_SOCKET"].ToString();
                cpu.consumoEnergetico = Convert.ToDouble(dt.Rows[i]["CONSUMO_ENERGIA"]);
                retVal.Add(cpu);    
            }
            return retVal;
        }
    }
}
