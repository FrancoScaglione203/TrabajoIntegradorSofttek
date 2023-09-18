using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {

        public ServicioRepository(ApplicationDbContext context) : base(context)
        {

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

    }
}