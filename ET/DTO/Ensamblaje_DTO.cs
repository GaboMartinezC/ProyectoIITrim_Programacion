using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class Ensamblaje_DTO
    {
        public int id { get; set; }
        public int idPlacaMadre { get; set; }
        public int idProcesador { get; set; }
        public int idEnfriamiento { get; set; }
        public int idRam { get; set; }
        public int cantidadRam { get; set; }
        public int idGrafica { get; set; }
        public int idCase { get; set; }
        public int idUnidadAlmacenamiento { get; set; }
        public int cantidadUnidades { get; set; }
        public int idFuente { get; set; }
    }
}
