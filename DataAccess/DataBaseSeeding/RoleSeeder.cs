using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Admin",
                    Activo = true,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Consulta",
                     Description = "Consulta",
                     Activo = true,
                 });
        }
    }
}
