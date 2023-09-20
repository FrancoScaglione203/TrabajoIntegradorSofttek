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
                    RoleId = 1,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234"),
                    Activo = true
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Eliana",
                    Dni = 11824320,
                    RoleId = 2,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234"),
                    Activo = true
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Juan",
                    Dni = 42446530,
                    RoleId = 2,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234"),
                    Activo = true
                });
        }
    }
}