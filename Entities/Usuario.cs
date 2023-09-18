using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Usuario
    {
        public Usuario(AgregarUsuarioDto dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Clave = dto.Clave;
            Activo = true;
        }

        public Usuario(AgregarUsuarioDto dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Clave = dto.Clave;
            Activo = true;
        }

        public Usuario()
        {

        }

        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }
        [Required]
        [Column("usuario_nombre", TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column("usuario_dni")]
        public int Dni { get; set; }
        [Required]
        [Column("usuario_tipo")]
        public int Tipo { get; set; }
        [Required]
        [Column("usuario_clave", TypeName = "VARCHAR(50)")]
        public string Clave { get; set; }
        [Required]
        [Column("usuario_activo")]
        public bool Activo { get; set; }
    }
}
