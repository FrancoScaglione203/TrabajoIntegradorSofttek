using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.DataAccess.Repositories;
using TrabajoIntegradorSofttek.Helpers;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Usuario updateUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == updateUsuario.Id);
            if (usuario == null) { return false; }

            usuario.Nombre = updateUsuario.Nombre;
            usuario.RoleId = updateUsuario.RoleId;
            usuario.Dni = updateUsuario.Dni;
            usuario.Cuil = updateUsuario.Cuil;
            usuario.Clave = updateUsuario.Clave;
            usuario.Activo = updateUsuario.Activo;

            _context.Usuarios.Update(usuario);
            return true;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) { return false; }

            usuario.Activo = false;

            _context.Usuarios.Update(usuario);
            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var user = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Usuarios.Remove(user);
            }

            return true;
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.Include(x=> x.Role).SingleOrDefaultAsync(x => x.Cuil == dto.Cuil && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Cuil));
        }
    }
}