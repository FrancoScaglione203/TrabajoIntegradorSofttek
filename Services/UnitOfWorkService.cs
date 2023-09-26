using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.DataAccess.Repositories;

namespace TrabajoIntegradorSofttek.Services
{
    /// <summary>
    /// Implementación de la interfaz IUnitOfWork que proporciona acceso a los repositorios de entidades de la base de datos
    /// </summary>
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public TrabajoRepository TrabajoRepository { get; private set; }
        public ServicioRepository ServicioRepository { get; private set; }
        public ProyectoRepository ProyectoRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase UnitOfWorkService con el contexto de base de datos proporcionado
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            TrabajoRepository = new TrabajoRepository(_context);
            ServicioRepository = new ServicioRepository(_context);
            ProyectoRepository = new ProyectoRepository(_context);
            RoleRepository = new RoleRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}