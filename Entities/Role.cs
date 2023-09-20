using System.ComponentModel.DataAnnotations.Schema;
using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Role
    {
        [Column("role_id")]
        public int Id { get; set; }
        [Column("role_name")]
        public string Name { get; set; }
        [Column("role_description")]
        public string Description { get; set; }
        [Column("role_activo")]
        public bool Activo { get; set; }

        public Role(RoleDto dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            Activo = dto.Activo;
        }
        public Role()
        {

        }
    }
}
