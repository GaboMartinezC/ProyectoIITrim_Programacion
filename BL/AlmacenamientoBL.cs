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
        //Metodo que convierte una datatable a una lista 
        public List<Almacenamiento_DTO> BuscarAlmacenamiento()
        {
            DataTable dt = dal.BuscarAlmacenamiento();
            List<Almacenamiento_DTO> retVal = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Instancia un objeto almacenamiento DTO y llena sus datos con los del recorrido actual de la datatable
                Almacenamiento_DTO almDto = new();
                almDto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                almDto.descripcion = dt.Rows[i]["DESCRIPCION"].ToString();
                almDto.capacidad = Convert.ToInt32(dt.Rows[i]["CAPACIDAD"]);
                almDto.consumoEnergia = Convert.ToDouble(dt.Rows[i]["CONSUMO_ENERGIA"]);
                almDto.m2 = Convert.ToBoolean(dt.Rows[i]["M2"]);
                //los introduce en la lista
                retVal.Add(almDto);
            }
            return retVal;
        }
    }
}
