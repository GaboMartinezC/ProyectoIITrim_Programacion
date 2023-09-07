using DAL;
using ET.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SocketBL
    {
        private SocketDAL dal = new();
        public List<Socket_DTO> BuscarSocket()
        {
            List<Socket_DTO> retVal = new();
            var dt= dal.BuscarSocket();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Socket_DTO dto = new();
                dto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                dto.descripcion = dt.Rows[i]["DESCRIPCION_SOCKET"].ToString();
                dto.lga = Convert.ToBoolean(dt.Rows[i]["LGA"]);
                retVal.Add(dto);
            }
            return retVal;
        }
    }
}
