using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.DataAccess.Repositories;

namespace TrabajoIntegradorSofttek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
        }

    }
}