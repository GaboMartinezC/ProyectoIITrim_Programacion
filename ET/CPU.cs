﻿namespace ET
{
    public class CPU
    {
        private int id;
        private string descripcion;
        private int idSocket;
        private double consumoEnergetico;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdSocket { get => idSocket; set => idSocket = value; }
        public double ConsumoEnergetico { get => consumoEnergetico; set => consumoEnergetico = value; }
    }
}