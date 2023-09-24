using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using TrabajoIntegradorSofttek.Services;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        private readonly IUnitOfWork _unitOfWorkService;
        public ServicioRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<Servicio>> GetActivos()
        {
            var activeServices = await _context.Servicios.Where(x => x.Activo == true).ToListAsync();
            return activeServices;
        }

        public override async Task<bool> Update(Servicio updateServicio)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == updateServicio.Id);
            if (servicio == null) { return false; }

            servicio.Descripcion = updateServicio.Descripcion;
            servicio.Estado = updateServicio.Estado;
            servicio.ValorHora = updateServicio.ValorHora;
            servicio.Activo = updateServicio.Activo;

            _context.Servicios.Update(servicio);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == id);
            if (servicio == null) { return false; }

            servicio.Activo = false;

            _context.Servicios.Update(servicio);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var servicio = await _context.Servicios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            return true;
        }

        //Funcion que devuelva true si existe un servicio con la descripcion que se manda por parametro
        public async Task<bool> ServicioEx(string Desc)
        {
            return await _context.Servicios.AnyAsync(x => x.Descripcion == Desc);
        }

    }
}