using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {

        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}