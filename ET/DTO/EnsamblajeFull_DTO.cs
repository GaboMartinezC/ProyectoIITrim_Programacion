using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.DTO
{
    public class EnsamblajeFull_DTO : Ensamblaje
    {
        public List<Almacenamiento_DTO> listaAlmacenamiento = new();
        public List<Case_DTO> listaCase = new();
        public List<CPU_DTO> listaCPU = new();
        public List<Enfriamiento_DTO> listaSistEnfriamiento = new();
        public List<FuentePoder_DTO> listaFuente = new();
        public List<GPU_DTO> listaGPU = new();
        public List<PlacaMadre_DTO> listaPlaca = new();
        public List<RAM_DTO> listaRAM = new();
    }
}
