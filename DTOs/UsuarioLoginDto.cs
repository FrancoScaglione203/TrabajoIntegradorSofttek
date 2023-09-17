namespace TrabajoIntegradorSofttek.DTOs
{
    public class UsuarioLoginDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public int? Dni { get; set; }
        public string Token { get; set; }
    }
}