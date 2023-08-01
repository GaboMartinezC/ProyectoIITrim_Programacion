using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FuentePoderBL
    {
        FuentePoderDAL dal = new FuentePoderDAL();
        public bool IngresarFuentePoder(FuentePoder fuentePoder)
        {
            string descripcion = string.Empty;
            DataTable listaFuentes = dal.BuscarFuentePoder();
            for (int i = 0; i < listaFuentes.Rows.Count; i++)
            {
                descripcion = listaFuentes.Rows[i]["DESCRIPCION"].ToString();
                if (descripcion.Equals(fuentePoder.Descripcion))
                    return false;
            }
            return dal.IngresarFuentePoder(fuentePoder);
        }
        public bool ActualizarFuentePoder(FuentePoder fuentePoder)
        {
            return dal.ActualizarFuentePoder(fuentePoder);
        }
        public bool EliminarFuentePoder(int id)
        {
            return dal.EliminarFuentePoder(id);
        }
        public DataTable BuscarFuentePoder()
        {
            return dal.BuscarFuentePoder();
        }
    }
}
