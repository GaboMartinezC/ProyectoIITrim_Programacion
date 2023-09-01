using DAL;
using ET.DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class EnfriamientoBL
    {
        private EnfriamientoDAL dal = new();
        public bool IngresarEnfriamiento(Enfriamiento enfriamiento)
        {
            string descripcion = string.Empty;
            DataTable listEnfriamiento = dal.BuscarEnfriamiento();
            for (int i = 0; i < listEnfriamiento.Rows.Count; i++)
            {
                descripcion = listEnfriamiento.Rows[i]["DESCRIPCION_ENFRIAMIENTO"].ToString();
                if (descripcion.Equals(enfriamiento.Descripcion))
                    return false;
            }
            return dal.IngresarEnfriamiento(enfriamiento);
        }
        public bool ActualizarEnfriamiento(Enfriamiento enfriamiento)
        {
            return dal.ActualizarEnfriamiento(enfriamiento);
        }
        public bool EliminarEnfriamiento(int id)
        {
            return dal.EliminarEnfriamiento(id);
        }
        public List<Enfriamiento_DTO> BuscarEnfriamiento()
        {
            List<Enfriamiento_DTO> retVal = new();
            DataTable dt = dal.BuscarEnfriamiento();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Enfriamiento_DTO enf = new();
                enf.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                enf.descripcion = dt.Rows[i]["DESCRIPCION_ENFRIAMIENTO"].ToString();
                enf.idSocket = Convert.ToInt32(dt.Rows[i]["ID_SOCKET"]);
                enf.descripcionSocket = dt.Rows[i]["DESCRIPCION_SOCKET"].ToString();
                enf.liquido = Convert.ToBoolean(dt.Rows[i]["REFRIGERACION_LIQUIDA"]);
                retVal.Add(enf);
            }
            return retVal;
        }
    }
}
