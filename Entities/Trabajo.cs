using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Trabajo
    {
        public Trabajo(TrabajoDto dto)
        {
            Fecha = dto.Fecha;
            ProyectoId = dto.IdProyecto;
            ServicioId = dto.IdServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.CantHoras * dto.ValorHora;
            Activo = true;
        }

        public Trabajo(TrabajoDto dto, int id)
        {
            Id = id;
            Fecha = dto.Fecha;
            ProyectoId = dto.IdProyecto;
            ServicioId = dto.IdServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.CantHoras * dto.ValorHora;   //Despues modificar cuando arregle la propiedad
            Activo = dto.Activo;
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
        [Column("proyecto_id")]
        public int ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }
        [Required]
        [Column("servicio_id")]
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
        [Required]
        [Column("trabajo_cantHoras")]
        public int CantHoras { get; set; }
        [Required]
        [Column("trabajo_valorHora")]
        public decimal ValorHora { get; set; }
        [Required]
        [Column("trabajo_costo")]
        public decimal Costo { get; set; }
        [Required]
        [Column("trabajo_activo")]
        public bool Activo { get; set; }

    }
}
