using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class PlacaMadre
    {
        private int id;
        private string descripcion;
        private int idFactorForma;
        private int idSocket;
        private int cantidadSATA;
        private int cantidadPCIe16;
        private int cantidadPCIe8;
        private int versionDDR;
        private int cantidadSlotsRAM;
        private int limiteRAM;
        private int cantidadM2;
        private double consumoEnergia;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdFactorForma { get => idFactorForma; set => idFactorForma = value; }
        public int IdSocket { get => idSocket; set => idSocket = value; }
        public int CantidadSATA { get => cantidadSATA; set => cantidadSATA = value; }
        public int CantidadPCIe16 { get => cantidadPCIe16; set => cantidadPCIe16 = value; }
        public int CantidadPCIe8 { get => cantidadPCIe8; set => cantidadPCIe8 = value; }
        public int VersionDDR { get => versionDDR; set => versionDDR = value; }
        public int CantidadSlotsRAM { get => cantidadSlotsRAM; set => cantidadSlotsRAM = value; }
        public int LimiteRAM { get => limiteRAM; set => limiteRAM = value; }
        public int CantidadM2 { get => cantidadM2; set => cantidadM2 = value; }
        public double ConsumoEnergia { get => consumoEnergia; set => consumoEnergia = value; }
    }
}
