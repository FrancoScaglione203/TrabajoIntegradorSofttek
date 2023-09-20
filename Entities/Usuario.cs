using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Helpers;

namespace TrabajoIntegradorSofttek.Entities
{
    public class Usuario
    {
        public Usuario(AgregarUsuarioDto dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            RoleId = 2;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave); //Despues agregar propiedad cuil
            Activo = true;
        }

        public Usuario(AgregarUsuarioDto dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            RoleId = dto.IdRole;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave); //Despues agregar propiedad cuil
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
        //[Required]
        //[Column("usuario_cuil")]
        //public int Cuil { get; set; }
        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        [Required]
        [Column("usuario_clave", TypeName = "VARCHAR(250)")]
        public string Clave { get; set; }
        [Required]
        [Column("usuario_activo")]
        public bool Activo { get; set; }

    }
}
