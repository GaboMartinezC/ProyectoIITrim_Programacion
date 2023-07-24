using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Case
    {
        private int id;
        private string descripcion;
        private int idFactorForma;
        private bool refrigeracionLiquida;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdFactorForma { get => idFactorForma; set => idFactorForma = value; }
        public bool RefrigeracionLiquida { get => refrigeracionLiquida; set => refrigeracionLiquida = value; }
    }
}
