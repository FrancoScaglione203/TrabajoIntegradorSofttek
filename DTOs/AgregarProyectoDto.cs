using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegradorSofttek.DTOs
{
    public class AgregarProyectoDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        public bool Activo { get; set; }
    }
}
