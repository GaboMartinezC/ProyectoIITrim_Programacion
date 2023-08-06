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
    public class CaseBL
    {
        private CaseDAL dal = new();
        public List<Case_DTO> BuscarCase()
        {
            List<Case_DTO> retVal = new();
            DataTable dt = dal.BuscarCase();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                Case_DTO caseDto = new();
                caseDto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                caseDto.descripcion = dt.Rows[i]["DESCRIPCION"].ToString();
                caseDto.idFactorForma = Convert.ToInt32(dt.Rows[i]["ID_FACTOR_FORMA"]);
                caseDto.descripFactorForm = dt.Rows[i]["DESCRIPCION_FACTOR_FORMA"].ToString();
                caseDto.refrigeracionLiquida = Convert.ToBoolean(dt.Rows[i]["REFRIGERACION_LIQUIDA"]);
                retVal.Add(caseDto);
            }
            return retVal;
        }
    }
}
