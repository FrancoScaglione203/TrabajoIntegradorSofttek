namespace TrabajoIntegradorSofttek.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Activo { get; set; }
    }
}