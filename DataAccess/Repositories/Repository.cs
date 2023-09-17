using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofttek.DataAccess;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var TrabajoIntegradorSofttek = await _context.Set<T>().ToListAsync();
            return TrabajoIntegradorSofttek;
        }
    }
}