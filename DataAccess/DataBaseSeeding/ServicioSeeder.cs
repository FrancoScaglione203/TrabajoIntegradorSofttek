using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    Id = 1,
                    Descripcion = "Perforacion",
                    Estado = true,
                    ValorHora = 500,
                    Activo = true
                },
                new Servicio
                {
                    Id = 2,
                    Descripcion = "Extraccion",
                    Estado = true,
                    ValorHora = 400,
                    Activo = true
                },
                new Servicio
                {
                    Id = 3,
                    Descripcion = "Transporte",
                    Estado = true,
                    ValorHora = 300,
                    Activo = true
                });
        }
    }
}
