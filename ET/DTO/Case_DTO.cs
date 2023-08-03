using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class Case_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idFactorForma { get; set; }
        public bool refrigeracionLiquida { get; set; }
    }
}
