using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class RAM
    {
        private int id;
        private string descripcion;
        private int? versionDDR;
        private int? capacidad;
        private double? consumoEnergia;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int? VersionDDR { get => versionDDR; set => versionDDR = value; }
        public int? Capacidad { get => capacidad; set => capacidad = value; }
        public double? ConsumoEnergia { get => consumoEnergia; set => consumoEnergia = value; }
    }
}
