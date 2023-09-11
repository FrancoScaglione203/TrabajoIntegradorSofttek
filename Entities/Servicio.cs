namespace TrabajoIntegradorSofttek.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }
        bool Activo { get; set; }
    }
}
