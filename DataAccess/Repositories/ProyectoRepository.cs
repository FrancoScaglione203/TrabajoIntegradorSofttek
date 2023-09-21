using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {

        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Proyecto updateProyecto)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == updateProyecto.Id);
            if (proyecto == null) { return false; }

            proyecto.Nombre = updateProyecto.Nombre;
            proyecto.Direccion = updateProyecto.Direccion;
            proyecto.Estado = updateProyecto.Estado;
            proyecto.Activo = updateProyecto.Activo;

            _context.Proyectos.Update(proyecto);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null) { return false; }

            proyecto.Activo = false;

            _context.Proyectos.Update(proyecto);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var proyecto = await _context.Proyectos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }

            return true;
        }

        public async Task<List<Proyecto>> GetEstado(int estado)
        {
            var estadoProyectos = await _context.Proyectos.Where(x => x.Estado == estado).ToListAsync();
            return estadoProyectos;
        }

    }
}