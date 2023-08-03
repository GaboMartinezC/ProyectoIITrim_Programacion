using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class GPU_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int cantidadConectores { get; set; }
        public bool pcie16 { get; set; }
        public double consumoEnergia { get; set; }
    }
}
