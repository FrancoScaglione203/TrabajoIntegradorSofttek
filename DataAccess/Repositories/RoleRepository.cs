using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(ApplicationDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Funcion para actualizar el Role con el id del UpdateRole que se envia por parametro
        /// </summary>
        /// <param name="updateRole"></param>
        /// <returns>Retorna true si se actualizo correctamente o false si hubo un error</returns>
        public override async Task<bool> Update(Role updateRole)
        {
            var Role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == updateRole.Id);
            if (Role == null) { return false; }

            Role.Name = updateRole.Name;
            Role.Description = updateRole.Description;
            Role.Activo = updateRole.Activo;

            _context.Roles.Update(Role);
            return true;
        }

        /// <summary>
        /// Borra de forma fisica el role con el id que se envia por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true una vez finalizo el borrado</returns>
        public async Task<bool> Delete(int id)
        {
            var Role = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Role != null)
            {
                _context.Roles.Remove(Role);
            }

            return true;
        }

        /// <summary>
        /// Valida si ya existe un Role con el nombre que se envia por parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Retorna true si ya hay un role con ese nombre o false si no lo hay</returns>
        public async Task<bool> RoleEx(string nombre)
        {
            return await _context.Roles.AnyAsync(x => x.Name == nombre);
        }

        Task<List<Usuario>> IRepository<Usuario>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Usuario> IRepository<Usuario>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
