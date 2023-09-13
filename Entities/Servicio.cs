using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Servicio
    {
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
