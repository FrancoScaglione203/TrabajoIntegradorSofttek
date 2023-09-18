using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Servicio
    {
        public Servicio(AgregarServicioDto dto)
        {
            Descripcion = dto.Descripcion;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
            Activo = true;
        }

        public Servicio(AgregarServicioDto dto, int id)
        {
            Id = id;
            Descripcion = dto.Descripcion;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
            Activo = dto.Activo;
        }

        public Servicio()
        {

        }

        [Key]
        [Column("servicio_id")]
        public int Id { get; set; }
        [Required]
        [Column("servicio_descripcion", TypeName = "VARCHAR(150)")]
        public string Descripcion { get; set; }
        [Required]
        [Column("servicio_estado")]
        public bool Estado { get; set; }
        [Required]
        [Column("servicio_valorHora")]
        public decimal ValorHora { get; set; }
        [Required]
        [Column("servicio_activo")]
        public bool Activo { get; set; }
    }
}
