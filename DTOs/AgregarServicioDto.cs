using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegradorSofttek.DTOs
{
    public class AgregarServicioDto
    {

        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }
        public bool Activo { get; set; }
    }
}
