using DAL;using ET;
using ET.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EnsamblajeBL
    {
        private EnsamblajeDAL dal = new();
        public int IngresarEnsamblaje(Ensamblaje ensamblaje)
        {
            dal.IngresarEnsamblaje(ensamblaje);
            return 0;
        }
        public int ActualizarEnsamblaje(Ensamblaje ensamblaje)
        {
            dal.ActualizarEnsamblaje(ensamblaje);
            return 0;
        }
        public bool EliminarEnsamblaje(int id)
        {
            return dal.EliminarEnsamblaje(id);
        }
        public List<Ensamblaje_DTO> BuscarTodoEnsamblaje()
        {
            List<Ensamblaje_DTO> retVal = new();
            DataTable dt = dal.BuscarEnsamblaje();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ensamblaje_DTO dto = new();
                dto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                dto.idPlacaMadre = Convert.ToInt32(dt.Rows[i]["ID_PLACA_MADRE"]);
                dto.descripPlacaMadre = dt.Rows[i]["DESCRIPCION_PLACA"].ToString();
                dto.idProcesador = Convert.ToInt32(dt.Rows[i]["ID_PROCESADOR"]);
                dto.descripProcesador = dt.Rows[i]["DESCRIPCION_CPU"].ToString();
                dto.idEnfriamiento = Convert.ToInt32(dt.Rows[i]["ID_ENFRIAMIENTO"]);
                dto.descripcionSistEnfriamiento = dt.Rows[i]["DESCRIPCION_ENFRIAMIENTO"].ToString();
                dto.idRam = Convert.ToInt32(dt.Rows[i]["ID_RAM"]);
                dto.descripcionRam = dt.Rows[i]["DESCRIPCION_RAM"].ToString();
                dto.cantidadRam = Convert.ToInt32(dt.Rows[i]["CANTIDAD_RAM"]);
                dto.idUnidadAlmacenamiento = Convert.ToInt32(dt.Rows[i]["ID_ALMACENAMIENTO"]);
                dto.descripcionAlmacenamiento = dt.Rows[i]["DESCRIPCION_ALMACENAMIENTO"].ToString();
                dto.cantidadUnidades = Convert.ToInt32(dt.Rows[i]["CANTIDAD_UNIDADES"]);
                dto.idFuente = Convert.ToInt32(dt.Rows[i]["ID_FUENTE"]);
                dto.descripcionFuente = dt.Rows[i]["DESCRIPCION_FUENTE"].ToString();
                dto.idCase = Convert.ToInt32(dt.Rows[i]["ID_CASE"]);
                dto.descripcionCase = dt.Rows[i]["DESCRIPCION_CASES"].ToString();
                dto.idGrafica = Convert.ToInt32(dt.Rows[i]["ID_GRAFICA"]);
                dto.descripcionGrafica = dt.Rows[i]["DESCRIPCION_GPU"].ToString();
            }
            return retVal;
        }
    }
}
