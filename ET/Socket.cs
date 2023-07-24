using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Socket
    {
        private int id;
        private string descripcion;
        private bool lga;
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Lga { get => lga; set => lga = value; }
    }
}
