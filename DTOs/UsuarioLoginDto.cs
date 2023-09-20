namespace TrabajoIntegradorSofttek.DTOs
{
    public class UsuarioLoginDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RoleId { get; set; }
        public int? Dni { get; set; }
        public int? Cuil { get; set; }
        public string Token { get; set; }
    }
}