using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class Almacenamiento_DTO
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int capacidad { get; set; }
        public double consumoEnergia { get; set; }
        public bool m2 { get; set; }
    }
}
