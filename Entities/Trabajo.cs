namespace TrabajoIntegradorSofttek.Entities
{
    public class Trabajo
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProyecto { get; set; }
        public int IdServicio { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }
        bool Activo { get; set; }
    }
}
