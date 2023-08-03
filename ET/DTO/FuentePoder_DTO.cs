using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class FuentePoder_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int cantidadConectoresSATA { get; set; }
        public int cantidadConectoresPCIe { get; set; }
        public double potencia { get; set; }
        public double altura { get; set; }
        public double ancho { get; set; }
    }
}
