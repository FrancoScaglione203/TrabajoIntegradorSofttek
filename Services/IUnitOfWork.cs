using TrabajoIntegradorSofttek.DataAccess.Repositories;

namespace TrabajoIntegradorSofttek.Services
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Define una interfaz para acceder a los repositorios relacionados con las entidades de la base de datos.
        /// </summary>
        public UsuarioRepository UsuarioRepository { get; }
        public TrabajoRepository TrabajoRepository { get; }
        public ServicioRepository ServicioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
        public RoleRepository RoleRepository { get; }
        Task<int> Complete();
    }
}