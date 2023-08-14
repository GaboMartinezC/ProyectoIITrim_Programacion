using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class PlacaMadre_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idFactorForma { get; set; }
        public string descripFacForma { get; set; }
        public int idSocket { get; set; }
        public string descripSocket { get; set; }
        public int cantidadSATA { get; set; }
        public int cantidadPCIe16 { get; set; }
        public int cantidadPCIe8 { get; set; }
        public int versionDDR { get; set; }
        public int cantidadSlotsRAM { get; set; }
        public int limiteRAM { get; set; }
        public int cantidadM2 { get; set; }
        public double consumoEnergia { get; set; }
    }
}
