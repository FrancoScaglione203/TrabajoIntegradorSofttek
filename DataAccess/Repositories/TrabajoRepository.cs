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
            trabajo.Costo = updateTrabajo.Costo;   //Despues modificar cuando arregle la propiedad
            trabajo.Activo = updateTrabajo.Activo;

            _context.Trabajos.Update(trabajo);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.Id == id);
            if (trabajo == null) { return false; }

            trabajo.Activo = false;

            _context.Trabajos.Update(trabajo);
            return true;
        }
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