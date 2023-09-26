using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.Helpers;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Franco",
                    Dni = 41826520,
                    Cuil = 20418265206,
                    RoleId = 1,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 20418265206),
                    Activo = true                  
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Eliana",
                    Dni = 11824320,
                    Cuil = 27118243201,
                    RoleId = 2,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 27118243201),
                    Activo = true
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Juan",
                    Dni = 42446530,
                    RoleId = 2,
                    Cuil = 20424465306,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", 20424465306),
                    Activo = true
                });
        }
    }
}