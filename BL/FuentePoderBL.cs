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
    public class FuentePoderBL
    {
        FuentePoderDAL dal = new FuentePoderDAL();
        public bool IngresarFuentePoder(FuentePoder fuentePoder)
        {
            string descripcion = string.Empty;
            DataTable listaFuentes = dal.BuscarFuentePoder();
            for (int i = 0; i < listaFuentes.Rows.Count; i++)
            {
                descripcion = listaFuentes.Rows[i]["DESCRIPCION_FUENTE"].ToString();
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
        //Metodo que convierte una datatable a una lista 
        public List<FuentePoder_DTO> BuscarFuentePoder()
        {
            DataTable dt = dal.BuscarFuentePoder();
            List<FuentePoder_DTO> retVal = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Instancia un objeto fuente DTO y llena sus datos con los del recorrido actual de la datatable
                FuentePoder_DTO fuente = new FuentePoder_DTO();
                fuente.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                fuente.descripcion = dt.Rows[i]["DESCRIPCION_FUENTE"].ToString();
                fuente.cantidadConectoresSATA = Convert.ToInt32(dt.Rows[i]["CANTIDAD_SATA"]);
                fuente.cantidadConectoresPCIe = Convert.ToInt32(dt.Rows[i]["CANTIDAD_PCIE"]);
                fuente.potencia = Convert.ToDouble(dt.Rows[i]["POTENCIA"]);
                fuente.altura = Convert.ToDouble(dt.Rows[i]["ALTURA"]);
                fuente.ancho = Convert.ToDouble(dt.Rows[i]["ANCHO"]);
                //los introduce en la lista
                retVal.Add(fuente);
            }
            return retVal;
        }
    }
}
