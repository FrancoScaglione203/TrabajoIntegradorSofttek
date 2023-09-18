using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Trabajo
    {
        public Trabajo(AgregarTrabajoDto dto)
        {
            Fecha = dto.Fecha;
            IdProyecto = dto.IdProyecto;
            IdServicio = dto.IdServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Activo = true;
        }

        public Trabajo()
        {

        }

        [Key]
        [Column("trabajo_id")]
        public int Id { get; set; }
        [Required]
        [Column("trabajo_fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        [Column("trabajo_idProyecto")]
        public int IdProyecto { get; set; }
        [Required]
        [Column("trabajo_idServicio")]
        public int IdServicio { get; set; }
        [Required]
        [Column("trabajo_cantHoras")]
        public int CantHoras { get; set; }
        [Required]
        [Column("trabajo_valorHora")]
        public decimal ValorHora { get; set; }
        [Required]
        [Column("trabajo_costo")]
        public decimal Costo { get; set; } //Modificar
        [Required]
        [Column("trabajo_activo")]
        public bool Activo { get; set; }
    }
}
