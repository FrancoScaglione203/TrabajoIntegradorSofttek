using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.Entities;

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


        public virtual async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }
        

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLogico(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        //public async Task<List<Servicio>> GetActivos()
        //{
        //    var activeServices = await _context.Servicios.Where(x => x.Estado == true).ToListAsync();
        //    return activeServices;
        //}
    }
}