using ET;
using DAL;
using System.Data;

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
        public DataTable BuscarRam()
        {
            return dal.BuscarRAM();
        }
    }
}