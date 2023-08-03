using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class Enfriamiento_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idSocket { get; set; }
        public bool liquido { get; set; }
    }
}
