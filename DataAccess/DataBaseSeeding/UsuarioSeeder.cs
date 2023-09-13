using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;


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
                    Tipo = 1,
                    Clave = "1234",
                    Activo = true
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Eliana",
                    Dni = 11824320,
                    Tipo = 2,
                    Clave = "1234",
                    Activo = true
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Juan",
                    Dni = 42446530,
                    Tipo = 2,
                    Clave = "1234",
                    Activo = true
                });
        }
    }
}