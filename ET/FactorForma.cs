using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class FactorForma
    {
        private int id;
        private string descripcion;
        private double ancho;
        private double largo;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Ancho { get => ancho; set => ancho = value; }
        public double Largo { get => largo; set => largo = value; }
    }
}
