using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            var trabajo = new Trabajo
            {
                Id = 1,
                Fecha = DateTime.Now,
                ProyectoId = 1,
                ServicioId = 1,
                CantHoras = 1000,
                ValorHora = 150,
                Activo = true
            };
            trabajo.Costo = trabajo.CantHoras * trabajo.ValorHora;
            modelBuilder.Entity<Trabajo>().HasData(trabajo);
        }
    }
}
