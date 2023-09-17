using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {

        public ServicioRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}