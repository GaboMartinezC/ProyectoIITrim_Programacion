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
    public class AlmacenamientoBL
    {
        private AlmacenamientoDAL dal = new AlmacenamientoDAL();
        public bool IngresarAlmacenamiento(Almacenamiento almacenamiento)
        {
            string descripcion = string.Empty; 
            DataTable listaDispAlmacenamiento = dal.BuscarAlmacenamiento();
            for (int i = 0; i<listaDispAlmacenamiento.Rows.Count; i++)
            {
                descripcion = listaDispAlmacenamiento.Rows[i]["DESCRIPCION"].ToString();
                if (descripcion.Equals(almacenamiento.Descripcion))
                    return false;
            }
            return dal.IngresarAlmacenamiento(almacenamiento);
        }
        public bool ActualizarAlmacenamiento(Almacenamiento almacenamiento)
        {
            return dal.ActualizarAlmacenamiento(almacenamiento);
        }
        public bool EliminarAlmacenamiento(int id)
        {
            return dal.EliminarAlmacenamiento(id);
        }
        public DataTable BuscarAlmacenamiento() 
        {
            return dal.BuscarAlmacenamiento();
        }
    }
}
