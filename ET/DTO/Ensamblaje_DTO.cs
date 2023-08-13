namespace ET.DTO
{
    public class Ensamblaje_DTO
    {
        public int id { get; set; }
        public int idPlacaMadre { get; set; }
        public string descripPlacaMadre { get; set; }
        public int idProcesador { get; set; }
        public string descripProcesador { get; set; }
        public int idEnfriamiento { get; set; }
        public string descripcionSistEnfriamiento { get; set; }
        public int idRam { get; set; }
        public string descripcionRam { get; set; }
        public int cantidadRam { get; set; }
        public int idGrafica { get; set; }
        public string descripcionGrafica { get; set; }
        public int idCase { get; set; }
        public string descripcionCase { get; set; }
        public int idUnidadAlmacenamiento { get; set; }
        public string descripcionAlmacenamiento { get; set; }
        public int cantidadUnidades { get; set; }
        public int idFuente { get; set; }
        public string descripcionFuente { get; set; }
    }
}
