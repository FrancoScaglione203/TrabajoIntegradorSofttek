using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Proyecto
    {
        public Proyecto(ProyectoDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
            Activo = true;
        }

        public Proyecto(ProyectoDto dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
            Activo = dto.Activo;
        }

        public Proyecto()
        {

        }

        [Key]
        [Column("proyecto_id")]
        public int Id { get; set; }
        [Required]
        [Column("proyecto_nombre", TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column("proyecto_direccion", TypeName = "VARCHAR(50)")]
        public string Direccion { get; set; }
        [Required]
        [Column("proyecto_estado")]
        public int Estado { get; set; }
        [Required]
        [Column("proyecto_activo")]
        public bool Activo { get; set; }
    }
}
