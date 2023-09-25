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

        /// <summary>
        /// Devuelve lista de Servicios con Activo = true
        /// </summary>
        /// <returns>Retorna lista de serivicios con propiedad Activo = true</returns>
        public async Task<List<Servicio>> GetActivos()
        {
            var activeServices = await _context.Servicios.Where(x => x.Activo == true).ToListAsync();
            return activeServices;
        }

        /// <summary>
        /// Actualiza el servicio con el id del updateServicio que se envia por parametro
        /// </summary>
        /// <param name="updateServicio"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
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

        /// <summary>
        /// Cambia a true el estado de la propiedad Activo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualiza correctamente o false si ocurrio algun error</returns>
        public async Task<bool> AltaLogico(int id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == id);
            if (servicio == null) { return false; }

            servicio.Activo = false;

            _context.Servicios.Update(servicio);
            return true;
        }

        /// <summary>
        /// Cambia a false el estado de la propiedad Activo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualiza correctamente o false si ocurrio algun error</returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == id);
            if (servicio == null) { return false; }

            servicio.Activo = false;

            _context.Servicios.Update(servicio);
            return true;
        }

        /// <summary>
        /// Borra fisicamente el servicio con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true una vez realizado el borrado</returns>
        public async Task<bool> Delete(int id)
        {
            var servicio = await _context.Servicios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            return true;
        }

        /// <summary>
        /// Valida si ya existe un Servicio con la descripcion que se envia por parametro
        /// </summary>
        /// <param name="Desc"></param>
        /// <returns>Retorna true si ya existe servicio con esa descripcion o false si no existe</returns>
        public async Task<bool> ServicioEx(string Desc)
        {
            return await _context.Servicios.AnyAsync(x => x.Descripcion == Desc);
        }

    }
}