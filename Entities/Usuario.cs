using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Usuario
    {
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
