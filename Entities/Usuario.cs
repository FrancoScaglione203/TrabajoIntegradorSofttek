namespace TrabajoIntegradorSofttek.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; } 
        public string Clave { get; set; }
        bool Activo { get; set; }
    }
}
