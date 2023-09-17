using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {

        public TrabajoRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}