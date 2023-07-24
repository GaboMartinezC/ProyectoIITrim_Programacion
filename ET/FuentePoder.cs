using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class FuentePoder
    {
        private int id;
        private string descripcion;
        private int cantidadConectoresSATA;
        private int cantidadConectoresPCIe;
        private double potencia;
        private double altura;
        private double ancho;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CantidadConectoresSATA { get => cantidadConectoresSATA; set => cantidadConectoresSATA = value; }
        public int CantidadConectoresPCIe { get => cantidadConectoresPCIe; set => cantidadConectoresPCIe = value; }
        public double Potencia { get => potencia; set => potencia = value; }
        public double Altura { get => altura; set => altura = value; }
        public double Ancho { get => ancho; set => ancho = value; }
    }
}
