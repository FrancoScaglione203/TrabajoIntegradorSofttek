using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegradorSofttek.DTOs
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public long Cuil { get; set; }
        public int IdRole { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}
