using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Enfriamiento
    {
        private int id;
        private string descripcion;
        private int idSocket;
        private bool liquido;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdSocket { get => idSocket; set => idSocket = value; }
        public bool Liquido { get => liquido; set => liquido = value; }
    }
}
