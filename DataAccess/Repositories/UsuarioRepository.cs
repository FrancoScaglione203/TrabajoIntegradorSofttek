using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofttek.DataAccess;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.DataAccess.Repositories;
using TrabajoIntegradorSofttek.Helpers;
using Microsoft.AspNetCore.Components.Forms;

namespace TrabajoIntegradorSofttek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }
        /// <summary>
        /// Devuelve todos los usuarios con clave = null por seguridad
        /// </summary>
        /// <returns>Retorna lista de usuarios con clave = null</returns>
        public override async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            foreach (var usuario in usuarios)
            {
                usuario.Clave = "**********";
            }
            return usuarios;   
        }

        /// <summary>
        /// Devuelve usuario sin clave por seguridad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna usuario con la clave tapada por seguridad</returns>
        public override async Task<Usuario> GetById(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            usuario.Clave = "**********";
            return usuario;
        }

        /// <summary>
        /// Actualiza el usuario con el id de updateUsuario por el mismo 
        /// </summary>
        /// <param name="updateUsuario"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
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

        /// <summary>
        /// Actualiza Activo = true del trabajo con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
        public async Task<bool> AltaLogico(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) { return false; }

            usuario.Activo = true;

            _context.Usuarios.Update(usuario);
            return true;
        }

        /// <summary>
        /// Actualiza Activo = false del trabajo con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true si se actualizo o false si hubo algun error</returns>
        public async Task<bool> DeleteLogico(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (usuario == null) { return false; }

            usuario.Activo = false;

            _context.Usuarios.Update(usuario);
            return true;
        }

        /// <summary>
        /// BGorra fisicamente el trabajo con el id enviado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna true una vez finalizado el borrado</returns>
        public async Task<bool> Delete(int id)
        {
            var user = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Usuarios.Remove(user);
            }

            return true;
        }

        /// <summary>
        /// Devuelve Usuario que tenga Cuil y clave iguales a las del AuthenticateDto que se envia por parametro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Si coincide cuil y clave retorna el usuario sino retorna Null</returns>
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.Include(x=> x.Role).SingleOrDefaultAsync(x => x.Cuil == dto.Cuil && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Cuil));
        }

        /// <summary>
        /// Valida si ya existe un usuario con el cuil que se envia por parametro
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Retorna true si ya existe o false si no existe</returns>
        public async Task<bool> UsuarioEx(long cuil)
        {
            return await _context.Usuarios.AnyAsync(x => x.Cuil == cuil);
        }
    }
}