using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;
using TrabajoIntegradorSofttek.Services;
using Microsoft.AspNetCore.Authorization;

namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet] 
        [Route("Usuarios")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult AgregarUsuario(UsuarioDto usuario)
        {
            return Unauthorized("No se pudo agregar usuario");
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarUsuario(UsuarioDto usuario)
        {
            return Ok(usuario);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarUsuario(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }

    }
}