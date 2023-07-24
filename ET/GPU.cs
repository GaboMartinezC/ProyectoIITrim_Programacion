using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class GPU
    {
        private int id;
        private string descripcion;
        private int cantidadConectores;
        private bool pcie16;
        private double consumoEnergia;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantidadConectores { get => cantidadConectores; set => cantidadConectores = value; }
        public bool Pcie16 { get => pcie16; set => pcie16 = value; }
        public double ConsumoEnergia { get => consumoEnergia; set => consumoEnergia = value; }
    }
}
