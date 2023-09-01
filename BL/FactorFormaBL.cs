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
    public class FactorFormaBL
    {
        private FactorFormaDAL dal = new();
        public bool IngresarFactorForma(FactorForma factorForma) 
        {
            string descripcion = string.Empty;
            DataTable listFactorForma = dal.BuscarFactorForma();
            for (int i = 0; i < listFactorForma.Rows.Count; i++)
            {
                descripcion = listFactorForma.Rows[i]["DESCRIPCION_FACTOR_FORMA"].ToString();
                if (descripcion.Equals(factorForma.Descripcion))
                    return false;
            }
            return dal.IngresarFactorForma(factorForma);
        }
        public bool ActualizarFactorForma(FactorForma factorForma)
        {
            return dal.ActualizarFactorForma(factorForma);
        }
        public bool EliminarFactorForma(int id)
        {
            return dal.EliminarFactorForma(id);
        }
        public List<FactorForma_DTO> BuscarFactorForma()
        {
            List<FactorForma_DTO> retVal = new();
            DataTable dt = dal.BuscarFactorForma();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FactorForma_DTO factorForma = new ();
                factorForma.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                factorForma.descripcion = dt.Rows[i]["DESCRIPCION_FACTOR_FORMA"].ToString();
                factorForma.ancho = Convert.ToDouble(dt.Rows[i]["ANCHO"]);
                factorForma.largo = Convert.ToDouble(dt.Rows[i]["LARGO"]);
                retVal.Add(factorForma);
            }
            return retVal;
        }
    }
}
