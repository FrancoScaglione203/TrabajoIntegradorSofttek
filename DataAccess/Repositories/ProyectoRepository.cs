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

        /// <summary>
        /// Busca el id del proyecto enviado por parametro y luego lo remplaza con los datos del mismo
        /// </summary>
        /// <param name="updateProyecto"></param>
        /// <returns>Retorna true si se actualizo correctamente o false si no hay ninguno con ese id para actualizar</returns>
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

        /// <summary>
        /// Busca el proyecto por el id que se envia por parametro y cambia Activo = true
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se modifico correctamente o false si no se encontro el id</returns>
        public async Task<bool> AltaLogico(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null) { return false; }

            proyecto.Activo = true;

            _context.Proyectos.Update(proyecto);
            return true;
        }

        /// <summary>
        /// Busca el proyecto por el id que se envia por parametro y cambia Activo = false
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se modifico correctamente o false si no se encontro el id</returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null) { return false; }

            proyecto.Activo = false;

            _context.Proyectos.Update(proyecto);
            return true;
        }

        /// <summary>
        /// Borra de forma fisica el proyecto con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true una vez finalizado el borrado</returns>
        public async Task<bool> Delete(int id)
        {
            var proyecto = await _context.Proyectos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }

            return true;
        }

        /// <summary>
        /// Devuelve lista de proyectos filtrados por el Estado que se envia por parametro
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna lista de proyectos con el estado seleccionado</returns>
        public async Task<List<Proyecto>> GetEstado(int estado)
        {
            var estadoProyectos = await _context.Proyectos.Where(x => x.Estado == estado).ToListAsync();
            return estadoProyectos;
        }

        /// <summary>
        /// Funcion que valida si ya existe un proyecto con el nombre que se envia por parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Retorna true si encontro uno con el mimsmo nombre o false si no encontro ninguno</returns>
        public async Task<bool> ProyectoEx(string nombre)
        {
            return await _context.Proyectos.AnyAsync(x => x.Nombre == nombre);
        }
    }
}