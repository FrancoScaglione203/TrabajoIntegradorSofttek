using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().HasData(
                new Trabajo
                {
                    Id = 1,
                    Fecha = DateTime.Now,
                    IdProyecto = 1,
                    IdServicio = 1,
                    CantHoras = 1000,
                    ValorHora = 150,
                    Costo = 150000,
                    Activo = true
                });
        }
    }
}
