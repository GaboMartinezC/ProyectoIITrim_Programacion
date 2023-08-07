using ET.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Almacenamiento
    {
        private int id;
        private string descripcion;
        private int capacidad;
        private double consumoEnergia;
        private bool m2;
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public double ConsumoEnergia { get => consumoEnergia; set => consumoEnergia = value; }
        public bool M2 { get => m2; set => m2 = value; }
    }
}
