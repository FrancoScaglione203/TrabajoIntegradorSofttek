using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.DataAccess.Repositories;

namespace TrabajoIntegradorSofttek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public TrabajoRepository TrabajoRepository { get; private set; }
        public ServicioRepository ServicioRepository { get; private set; }
        public ProyectoRepository ProyectoRepository { get; private set; }


        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            TrabajoRepository = new TrabajoRepository(_context);
            ServicioRepository = new ServicioRepository(_context);
            ProyectoRepository = new ProyectoRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}