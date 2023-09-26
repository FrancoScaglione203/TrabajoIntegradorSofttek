using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {

        public TrabajoRepository(ApplicationDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Actualiza el trabajo que tiene el id de UpdateTrabajo y lo remplaza por el mismo
        /// </summary>
        /// <param name="updateTrabajo"></param>
        /// <returns>Retorna true si se actualizo correctamente o false si ocurre un error</returns>
        public override async Task<bool> Update(Trabajo updateTrabajo)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.Id == updateTrabajo.Id);
            if (trabajo == null) { return false; }

            
            trabajo.Activo = updateTrabajo.Activo;
            trabajo.Fecha = updateTrabajo.Fecha;
            trabajo.ProyectoId = updateTrabajo.ProyectoId;
            trabajo.ServicioId = updateTrabajo.ServicioId;
            trabajo.CantHoras = updateTrabajo.CantHoras;
            trabajo.ValorHora = updateTrabajo.ValorHora;
            trabajo.Costo = updateTrabajo.Costo;   
            trabajo.Activo = updateTrabajo.Activo;

            _context.Trabajos.Update(trabajo);
            return true;
        }

        /// <summary>
        /// Cambia a true la propiedad Activo del trabajo con id igual al enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualizo correctamente o false si ocurre un error</returns>
        public async Task<bool> AltaLogico(int id)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.Id == id);
            if (trabajo == null) { return false; }

            trabajo.Activo = true;

            _context.Trabajos.Update(trabajo);
            return true;
        }

        /// <summary>
        /// Cambia a false la propiedad Activo del trabajo con id igual al enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualizo correctamente o false si ocurre un error</returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.Id == id);
            if (trabajo == null) { return false; }

            trabajo.Activo = false;

            _context.Trabajos.Update(trabajo);
            return true;
        }

        /// <summary>
        /// Borra fisicamente el trabajo seleccionado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true una vez finalizado el borrado</returns>
        public async Task<bool> Delete(int id)
        {
            var trabajo = await _context.Trabajos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (trabajo != null)
            {
                _context.Trabajos.Remove(trabajo);
            }

            return true;
        }

    }
}