using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.DataAccess.DataBaseSeeding;
using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new ServicioSeeder(),
                new ProyectoSeeder(),
                new TrabajoSeeder(),
                new RoleSeeder(),
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDataBase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}