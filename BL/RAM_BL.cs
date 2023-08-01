using ET;
using ET.DTO;
using DAL;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace BL
{
    public class RAM_BL
    {
        private RAM_DAL dal = new RAM_DAL();
        public bool IngresarRam(RAM ram)
        {
            string descripcion = string.Empty;
            DataTable listaRAM = dal.BuscarRAM();
            for (int i = 0; i < listaRAM.Rows.Count; i++)
            {
                descripcion = listaRAM.Rows[i]["DESCRIPCION"].ToString();
                if (descripcion.Equals(ram.Descripcion))
                    return false;
            }
            return dal.IngresarRAM(ram);
        }
        public bool ActualizarRam(RAM ram)
        {
            return dal.ActualizarRAM(ram);
        }
        public bool EliminarRam(int id)
        {
            return dal.EliminarRAM(id);
        }
        public List<RAM_DTO> BuscarRam()
        {
            List<RAM_DTO> retVal = new();
            DataTable listaRAM = dal.BuscarRAM();
            for (int i = 0; i < listaRAM.Rows.Count; i++)
            {
                RAM_DTO ram = new RAM_DTO();
                ram.Id = Convert.ToInt32(listaRAM.Rows[i]["ID"]);
                ram.Descripcion = listaRAM.Rows[i]["DESCRIPCION"].ToString();
                ram.VersionDDR = Convert.ToInt32(listaRAM.Rows[i]["VERSION_DDR"]);
                ram.Capacidad = Convert.ToInt32(listaRAM.Rows[i]["CAPACIDAD"]);
                ram.ConsumoEnergia = Convert.ToDouble(listaRAM.Rows[i]["CAPACIDAD"]);
                retVal.Add(ram);
            }
            return retVal;
        }
    }
}