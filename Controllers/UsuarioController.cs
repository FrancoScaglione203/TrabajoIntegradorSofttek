using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofttek.Entities;
using TrabajoIntegradorSofttek.DTOs;


namespace TrabajoIntegradorSofttek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios()
        {
            return Ok("Todos los usuarios");
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