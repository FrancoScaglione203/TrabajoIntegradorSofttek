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
            usuario.Clave = updateUsuario.Clave;
            usuario.Activo = updateUsuario.Activo;

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

        //CODIGO PARA BORRADO LOGICO
        //public override async Task<bool> Delete(Usuario deleteUsuario)
        //{
        //    var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == deleteUsuario.Id);
        //    if (usuario == null) { return false; }

        //    usuario.Activo = false;

        //    _context.Usuarios.Update(usuario);
        //    return true;
        //}


        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Dni == dto.Dni && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave));
        }
    }
}