using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces
{
    public interface IProyectoRepository : IRepository<Proyecto>
    {
        public Task<List<Proyecto>> GetEstado(int estado);
    }
}
