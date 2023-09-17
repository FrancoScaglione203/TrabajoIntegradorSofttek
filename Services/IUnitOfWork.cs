using TrabajoIntegradorSofttek.DataAccess.Repositories;

namespace TrabajoIntegradorSofttek.Services
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
    }
}