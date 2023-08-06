using DAL;
using ET.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactorForma
    {
        private FactorFormaDAL dal = new();
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
