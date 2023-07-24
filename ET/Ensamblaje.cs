using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Ensamblaje
    {
        private int id;
        private int idPlacaMadre;
        private int idProcesador;
        private int idEnfriamiento;
        private int idRam;
        private int cantidadRam;
        private int idGrafica;
        private int idCase;
        private int idUnidadAlmacenamiento;
        private int cantidadUnidades;
        private int idFuente;

        public int Id { get => id; set => id = value; }
        public int IdPlacaMadre { get => idPlacaMadre; set => idPlacaMadre = value; }
        public int IdProcesador { get => idProcesador; set => idProcesador = value; }
        public int IdEnfriamiento { get => idEnfriamiento; set => idEnfriamiento = value; }
        public int IdRam { get => idRam; set => idRam = value; }
        public int CantidadRam { get => cantidadRam; set => cantidadRam = value; }
        public int IdGrafica { get => idGrafica; set => idGrafica = value; }
        public int IdCase { get => idCase; set => idCase = value; }
        public int IdUnidadAlmacenamiento { get => idUnidadAlmacenamiento; set => idUnidadAlmacenamiento = value; }
        public int CantidadUnidades { get => cantidadUnidades; set => cantidadUnidades = value; }
        public int IdFuente { get => idFuente; set => idFuente = value; }
    }
}
