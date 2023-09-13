using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    Id = 1,
                    Nombre = "Vaca Muerta",
                    Direccion = "Santa Fe 674, Rio Negro",
                    Estado = 1,
                    Activo = true
                },
                new Proyecto
                {
                    Id = 2,
                    Nombre = "Nueva Nieve",
                    Direccion = "Cajaraville 1093, Neuquen",
                    Estado = 2,
                    Activo = true
                },
                new Proyecto
                {
                    Id = 3,
                    Nombre = "Salinas Rojas",
                    Direccion = "Los Ceibos 5732, Chubut",
                    Estado = 3,
                    Activo = true
                });
        }
    }
}
