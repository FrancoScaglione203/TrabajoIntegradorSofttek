using TrabajoIntegradorSofttek.Entities;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //CODIGO PARA BORRADO LOGICO
        //public Task<bool> Delete(T entity); 
        public Task<List<T>> GetAll();
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}