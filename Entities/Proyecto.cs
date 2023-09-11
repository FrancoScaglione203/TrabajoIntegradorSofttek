namespace TrabajoIntegradorSofttek.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        bool Activo { get; set; }
    }
}
